using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Experimental;

public class scena3 : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5f;
    Animator animator;
    private bool isWalking;
    private bool jumpKeyWasPressed;
    private float horizInput, vertinput;
    private Rigidbody rigidcomponent;
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask playerMask;
    Vector3 velocity;
    public float gravity = -9.81f;
    public float jumpheight = 3;
    private bool isGrounded;
    public Camera camera;
    public Material mat;
    float cnt = 0;
    public float time = 3;
    public Image gaze;
    public GameObject ogg;
    Material ogmat;

    public bool open;
    public Transform Player;
    private Animator openandclose1;

    public string sceneName;
    public bool isnextscene = true;
    [SerializeField] public sceneInfo sceneinfo;
    public TextMeshProUGUI text;
    private int time2 = 5;
    public bool modified;
    public GameObject img;
    private BitArray explored = new BitArray(2);

    public GameObject prefabLibro1;
    private GameObject libro;

    // Start is called before the first frame update
    void Start()
    {
        // animator=GetComponent<Animator>();
        sceneinfo.scene = 3;
        rigidcomponent = GetComponent<Rigidbody>();
        gaze.fillAmount = 0;
        open = false;
        modified = false;
        ogmat = ogg.GetComponent<MeshRenderer>().material;
        openandclose1 = Player.gameObject.GetComponent<Animator>();
        text.text = "";
       
        
        explored.SetAll(false);
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        Vector3 v;
        v.x = Screen.width / 2;
        v.y = Screen.height / 2;
        v.z = -0.5f;

        Ray ray = camera.ScreenPointToRay(v);

        if (Physics.Raycast(ray, out hit))
        {

            Transform objecthit = hit.transform;


            if (objecthit.gameObject.CompareTag("keyboard"))
            {
                //ogg=objecthit.gameObject;
                cnt += Time.deltaTime;
                objecthit.gameObject.GetComponent<MeshRenderer>().material = mat;
                gaze.fillAmount = cnt / time;
                if (gaze.fillAmount == 1 && explored.Get(0)==true)
                {
                    sceneinfo.isnextscene = isnextscene;
                    SceneManager.LoadScene(sceneName);
                    cnt = 0;
                    gaze.fillAmount = 0;
                }
                else if (gaze.fillAmount == 1)
                {
                    
                    text.text = ("explore first");
                    modified = true;
                    cnt = 0;
                    gaze.fillAmount = 0;
                }


            }
            // door script
            else if (objecthit.gameObject.CompareTag("chest"))
            {
                if (open == false)
                {
                    cnt += Time.deltaTime;

                    gaze.fillAmount = cnt / time;
                    if (Player)
                    {

                        float dist = Vector3.Distance(Player.position, transform.position);
                        if (dist < 15)
                        {

                            if (gaze.fillAmount == 1)
                            {

                                
                                modified = true;
                                objecthit.gameObject.GetComponent<Animator>().Play("openchest");
                                cnt = 0;
                                gaze.fillAmount = 0;
                                open = true;


                            }




                        }
                    }
                }
            }
            else if (objecthit.gameObject.CompareTag("book"))
            {
                cnt += Time.deltaTime;
                gaze.fillAmount = cnt / time;
                if (gaze.fillAmount == 1)
                {
                    explored.Set(0, true);
                    modified = true;
                   // img.fillAmount = 1f;
                    cnt = 0;
                    gaze.fillAmount = 0;
                    libro = Instantiate(prefabLibro1, img.transform.position, img.transform.rotation);
                    GetComponent<CharacterController>().minMoveDistance = 1000f;
                }

            }
            else if (objecthit.gameObject.CompareTag("close"))
            {
                cnt += Time.deltaTime;
                gaze.fillAmount = cnt / time;
                if (gaze.fillAmount == 1)
                {
                    Destroy(libro);
                    modified = false;
                    GetComponent<CharacterController>().minMoveDistance = 0.001f;
                    cnt = 0;
                    gaze.fillAmount = 0;

                }
            }
            else if (objecthit.gameObject.CompareTag("height"))
            {
                if (open)
                {
                    cnt += Time.deltaTime;
                    gaze.fillAmount = cnt / time;
                    if (gaze.fillAmount == 1)
                    {
                        Destroy(objecthit.gameObject);
                        
                        text.text = ("variable taken");
                        modified = true;

                        cnt = 0;
                        gaze.fillAmount = 0;
                    }

                }
            }
            else
            {
                if (cnt > 0) cnt -= Time.deltaTime;
                gaze.fillAmount = cnt / time;
                if (gaze.fillAmount == 0) { ogg.GetComponent<MeshRenderer>().material = ogmat; }
            }

        }
        else
        {
            if (cnt > 0)
            {
                cnt -= Time.deltaTime;
                gaze.fillAmount = cnt / time;
            }
        }

        if (modified == true)
        {

            
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - 0.0005f);
           
        }


        if (text.color.a <= 0)
        {
            modified = false;
            text.text = "";

            text.color = new Color(text.color.r, text.color.g, text.color.b, 1);

        }

        isGrounded = Physics.CheckSphere(groundCheckTransform.position, 0.3f, playerMask);

        if (isGrounded && velocity.y < 0) { velocity.y = -2f; }
        //isWalking = animator.GetBool("isWalking");
        if (!isWalking && Input.GetKey("w"))
        {
            // animator.SetBool("isWalking", true);
        }
        if (isWalking && !Input.GetKey("w")) animator.SetBool("isWalking", false);



        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpKeyWasPressed = true;
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);


        }
        else jumpKeyWasPressed = false;

        //   animator.SetBool("jumps", jumpKeyWasPressed);

        horizInput = Input.GetAxis("Horizontal");
        vertinput = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizInput + transform.forward * vertinput;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void FixedUpdate()
    {

        /* rigidcomponent.velocity = new Vector3(horizInput , rigidcomponent.velocity.y, vertinput);
        
       // if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        //{
          //  return;
        //}
       */

        /*  if (jumpKeyWasPressed)
          {
              float jumpPower = 5f;
              rigidcomponent.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
              jumpKeyWasPressed = false;
          }*/
    }
    IEnumerator opening()
    {
        print("you are opening the door");
        openandclose1.Play("Opening 1");
        open = true;
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator closing()
    {
        print("you are closing the door");
        openandclose1.Play("Closing 1");
        open = false;
        yield return new WaitForSeconds(.5f);
    }
}
