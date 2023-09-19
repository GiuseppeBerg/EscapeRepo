using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Experimental;
using static UnityEditor.Experimental.GraphView.GraphView;
using System.Runtime.CompilerServices;


//using System.Numerics;
//using static System.Net.Mime.MediaTypeNames;
//using UnityEngine.UIElements;

public class scena2 : MonoBehaviour
{
    public CharacterController controller;
   
    public float speed = 5f;
    //Animator animator;
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
    public float time = 2;
    public Image gaze;
    // public GameObject ogg;
    Material ogmat;
    public GameObject prefabcube;
    public GameObject tempDown, tempUp;
    private bool open, open2,open3,open4;
    public TextMeshProUGUI text;
    public GameObject portasx;
    private Animator cabinanimatordx;
    private Animator cabinanimatorsx,openandclose1;
    public GameObject monitor;
    public GameObject portadx;
    

    public GameObject spawner,libro,prefablibro1,prefablibro2,prefablibro3;
    private Vector3 Pos;
    private Quaternion Rot;
    public bool interacted, placed,placed2, modified,modified1,scriptmachineright,scriptconduitright,smp,scp,canplace;
    public GameObject key, resetted,ladder;
    private string tagged,tagged1, pretext;
    private int z = 0;
    public Canvas img,imgmachine,imgconduit;
    public BitArray explored = new BitArray(2);

    public static scena2 playerInstance;

    [SerializeField] public sceneInfo sceneInfo;
    public GameObject space1, space2;
    public Transform slot1,place1,place2;
    private GameObject c, c1, tmp, scala1, scala2, scala3, invisible,spot1,spot2,pallapiazzata,cannonepiazzato,pallacaricata, palla, cannone,collidercannone,colliderpalla;
    private int pieno;
    private Vector3 t1,t2;
    private string s1, s2;
    // Start is called before the first frame update
    void Start()
    {
        
        //animator = GetComponent<Animator>();
        rigidcomponent = GetComponent<Rigidbody>();
    
        gaze.fillAmount = 0;
        open = false;
        open2 = false;
        open3 = false;
        open4 = false;
        placed = false;
        interacted = false;
        
        modified = false;
        text.text = "";
        tempUp=null; tempDown=null;
        sceneInfo.inventory = 0;
        space1 = null; space2=null;
        c1 = c = null;
        invisible = null;
        
        explored.SetAll(false);
        sceneInfo.actualscene = 1;

        

        //   ogmat = ogg.GetComponent<MeshRenderer>().material;
    }


    private void Awake()
    {
        
        DontDestroyOnLoad(gameObject);
        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        

        if (sceneInfo.changed == true && sceneInfo.actualscene == 2)
        {
            speed = 5;

            space1 = c;
            space2 = c1;
            
            
            open = false;
            open2 = false;
            open3 = false;
            sceneInfo.lvpassed = false;
            open4 = false;
            placed = false;
            interacted = false;
            
            modified = false;
            text.text = "";
            tempUp = null; tempDown = null;

            spawner = GameObject.Find("GlassTank");
            monitor = GameObject.Find("ScreenDisplay");

            portadx = GameObject.Find("CabinetDoorR");
            portasx = GameObject.Find("CabinetDoorL");
            cabinanimatordx = portadx.GetComponent<Animator>();
            cabinanimatorsx = portasx.GetComponent<Animator>();
            sceneInfo.changed = false;
        }
        else if (sceneInfo.changed == true && sceneInfo.actualscene == 1)
        {
            sceneInfo.changed = false;
            sceneInfo.scene = 1;
        }
        else if (sceneInfo.changed == true && sceneInfo.actualscene == 3)
        {
            if (sceneInfo.lvpassed==true)
            {
                space1 = null;
                space2=null;
                Destroy(c);
                Destroy(c1);
                c = null;
                c1 = null;
                open=false;
                open2 = false;
                open3 = false;
                sceneInfo.lunghezzascala = 0;
                sceneInfo.var = 0;
                open4 = false;
                placed = false;
                interacted = false;
               
                modified = false;
                text.text = "";
                tempUp = null; tempDown = null;
                sceneInfo.inventory = 0;
                sceneInfo.lvpassed = false;

            }
            sceneInfo.scene = 3;
            
            explored.SetAll(false);
            speed = 8;
            tmp = GameObject.Find("triggerplace");
            scala1 = GameObject.Find("Ladder");
           scala2 = GameObject.Find("Ladder (1)");
             scala3 = GameObject.Find("Ladder (2)");

            scala1.SetActive(false);
            scala2.SetActive(false);
            scala3.SetActive(false);
            if (sceneInfo.hasLadder) {
                
                tmp.SetActive(true);
            }

            else tmp.SetActive(false);
            sceneInfo.changed = false;
        }
        else if (sceneInfo.changed==true && sceneInfo.actualscene == 4)
        {
            if (sceneInfo.lvpassed == true)
            {
                space1 = null;
                space2 = null;
                Destroy(c);
                Destroy(c1);
                c = null;
                c1 = null;
                open = false;
                open2 = false;
                open3 = false;
                sceneInfo.lunghezzascala = 0;
                sceneInfo.var = 0;
                open4 = false;
                placed = false;
                interacted = false;
                canplace = false;
                modified = false;
                text.text = "";
                tempUp = null; tempDown = null;
                sceneInfo.inventory = 0;
                sceneInfo.lvpassed = false;


            }
            sceneInfo.scene = 4;
            explored.SetAll(false);
            pallacaricata = GameObject.Find("pallacaricata");
            pallapiazzata = GameObject.Find("pallapiazzata");
            cannonepiazzato = GameObject.Find("cannonepiazzato");
            palla= GameObject.Find("palla");
            cannone= GameObject.Find("cannone");
            pallacaricata.SetActive(false);
            pallapiazzata.SetActive(false);
            cannonepiazzato.SetActive(false);
            colliderpalla = GameObject.Find("colliderpalla");
            collidercannone = GameObject.Find("collidercannon");
            scriptmachineright = false;
            scriptconduitright = false;
            smp = false;
            scp = false;
            sceneInfo.changed=false;
        }
        
        RaycastHit hit;
        Vector3 v;
        v.x = Screen.width / 2;
        v.y = Screen.height / 2;
        v.z = -0.5f;
        Ray ray = camera.ScreenPointToRay(v);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objecthit = hit.transform;
            string tag = objecthit.gameObject.tag;
            int layer = objecthit.gameObject.layer;
            float dist = Vector3.Distance(objecthit.position, transform.position);

            if (layer == 9)
            {
                if (dist < 15 && sceneInfo.inventory < 2)
                {
                    cnt += Time.deltaTime;
                    gaze.fillAmount = cnt / time;
                    if (gaze.fillAmount == 1)
                    {

                        Pos = objecthit.position;
                        Rot = objecthit.rotation;

                        GameObject[] list = new GameObject[4];
                        list = Collect(objecthit.gameObject, c, c1, slot1, space1, space2);
                        c = list[0];
                        c1 = list[1];
                        space1 = list[2];
                        space2 = list[3];                       
                        cnt = 0;
                        gaze.fillAmount = 0;
                        text.text = "variable obtained";
                        modified = true;
                    }
                }
            }
            if (layer == 10)
            {

                cnt += Time.deltaTime;
               // gaze.fillAmount = cnt / time;
                cnt += Time.deltaTime;
                gaze.fillAmount = cnt / time;
                if (gaze.fillAmount == 1)
                {

                    if (pieno == 0)
                    {
                       
                        spot1.SetActive(false);
                        t1 = objecthit.transform.position;
                        objecthit.GetComponent<RectTransform>().position  = spot1.GetComponent<RectTransform>().position;
                        
                       objecthit.GetComponentInChildren<TextMeshProUGUI>().fontSize = 16;
                       s1= objecthit.GetComponentInChildren<TextMeshProUGUI>().text;
                        objecthit.gameObject.tag = "writed";
                        pieno++;
                    }
                    else if (pieno == 1)
                    {
                        if (!objecthit.gameObject.CompareTag("writed"))
                        {
                            if (objecthit.gameObject.CompareTag("writed2"))
                            {
                                objecthit.transform.position = t2;
                                objecthit.gameObject.tag = "Untagged";
                                objecthit.GetComponentInChildren<TextMeshProUGUI>().fontSize = 24;
                                s1 = null; s2=null;
                                pieno--;
                            }
                            else
                            {
                                spot2.SetActive(false);
                                t2 = objecthit.transform.position;
                                objecthit.GetComponent<RectTransform>().position = spot2.GetComponent<RectTransform>().position;
                                objecthit.GetComponentInChildren<TextMeshProUGUI>().fontSize = 16;
                                s2 = objecthit.GetComponentInChildren<TextMeshProUGUI>().text;
                                objecthit.gameObject.tag = "writed2";
                                pieno++;
                            }
                        }
                        else
                        {

                            pieno--;

                            objecthit.GetComponentInChildren<TextMeshProUGUI>().fontSize = 24;
                            objecthit.transform.position = t1;
                            objecthit.gameObject.tag = "Untagged";
                            s1 = null;
                        }
                    }
                    else
                    {
                        if (!objecthit.gameObject.CompareTag("writed") && !objecthit.gameObject.CompareTag("writed2"))
                        {
                            text.text = "Can't add more than one statement/condition";
                            modified = true;
                        }
                        else
                        {
                            if (objecthit.gameObject.CompareTag("writed"))
                            {
                                pieno--;
                                objecthit.transform.position = t1;
                              //  t1 = t2;
                               GameObject.FindWithTag("writed2").transform.position = spot1.GetComponent<RectTransform>().position;
                                objecthit.gameObject.tag = "Untagged";
                                objecthit.GetComponentInChildren<TextMeshProUGUI>().fontSize = 24;
                                s1 = null;
                            }
                            else if (objecthit.gameObject.CompareTag("writed2"))
                            {
                                pieno--;
                                objecthit.transform.position = t2;
                                objecthit.gameObject.tag = "Untagged";
                                objecthit.GetComponentInChildren<TextMeshProUGUI>().fontSize = 24;
                                s2 = null;

                            }
                        }
                    }
                    cnt = 0;
                    gaze.fillAmount = 0;

                }
            

            }
            switch (tag)
            {
                case "shoot":
                    cnt += Time.deltaTime;
                    gaze.fillAmount = cnt / time;
                    if (gaze.fillAmount == 1)
                    {
                        if (scriptmachineright)
                        {
                            pallacaricata.GetComponent<Animator>().Play("lanciapalla");
                         
                        }
                        else if (smp)
                        {

                            text.text = "the script is wrong, try again";
                        }
                        else text.text = "nothing appened, insert a script";
                        
                        modified = true;
                        cnt = 0;
                        gaze.fillAmount = 0;
                    }
                    break;
                case "scriptconduit":
                    cnt += Time.deltaTime;
                    gaze.fillAmount = cnt / time;
                    if (gaze.fillAmount == 1)
                    {
                        if (sceneInfo.inventory > 0)
                        {
                            GameObject[] list = new GameObject[4];
                            if (sceneInfo.hasC==true && c.CompareTag("conduitsheet"))
                            {
                                if (sceneInfo.rightC == true)
                                    scriptconduitright = true;
                                else scriptconduitright = false;
                                list = Put(c, c1, space1, space2);
                                c = list[0];
                                c1 = list[1];
                                space1 = list[2];
                                space2 = list[3];
                                
                                text.text = ("script placed");
                                scp = true;
                                sceneInfo.hasC = false; sceneInfo.rightC = false;

                            }
                            else if (sceneInfo.hasC == true &&  c1 != null && c1.CompareTag("conduitsheet"))
                            {
                                if (sceneInfo.rightC == true)
                                    scriptconduitright = true;
                                else scriptconduitright = false;
                                Destroy(c1);
                                c1 = null;
                                space2 = null;
                               
                                sceneInfo.inventory--;
                                text.text = ("script placed");
                                scp = true;
                                sceneInfo.hasC = false; sceneInfo.rightC = false;
                            }
                            else text.text = "no script to place";


                        }
                        else text.text = "inventory is empty";
                        modified = true;
                        cnt = 0;
                        gaze.fillAmount = 0;
                    }
                    break;
                case "scriptmachine":
                    cnt += Time.deltaTime;
                    gaze.fillAmount = cnt / time;
                    if (gaze.fillAmount == 1)
                    {
                        if (sceneInfo.inventory > 0)
                        {
                            GameObject[] list = new GameObject[4];
                            if (sceneInfo.hasM == true && c.CompareTag("conduitsheet"))
                            {
                                if (sceneInfo.rightM == true)
                                    scriptmachineright = true;
                                else scriptmachineright = false;
                                list = Put(c, c1, space1, space2);
                                c = list[0];
                                c1 = list[1];
                                space1 = list[2];
                                space2 = list[3];

                                text.text = ("script placed");
                                scp = true;
                                sceneInfo.hasM = false; sceneInfo.rightM = false;

                            }
                            else if (sceneInfo.hasM == true && c1 != null && c1.CompareTag("conduitsheet"))
                            {
                                if (sceneInfo.rightM == true)
                                    scriptmachineright = true;
                                else scriptmachineright = false;
                                Destroy(c1);
                                c1 = null;
                                space2 = null;

                                sceneInfo.inventory--;
                                text.text = ("script placed");
                                smp = true;
                                sceneInfo.hasM = false; sceneInfo.rightM = false;

                            }
                            else text.text = "no script to place";


                        }
                        else text.text = "inventory is empty";
                        modified = true;
                        cnt = 0;
                        gaze.fillAmount = 0;
                    }
                    break;
                case "placeball":
                    cnt += Time.deltaTime;
                    gaze.fillAmount = cnt / time;
                    if (gaze.fillAmount == 1)
                    {
                        if (sceneInfo.inventory > 0)
                        {
                            GameObject[] list = new GameObject[4];
                            if (canplace)
                            {
                                if (c.CompareTag("palla"))
                                {
                                    list = Put(c, c1, space1, space2);
                                    c = list[0];
                                    c1 = list[1];
                                    space1 = list[2];
                                    space2 = list[3];
                                    pallapiazzata.SetActive(true);
                                    text.text = ("object placed");
                                    colliderpalla.SetActive(false);
                                    if (scriptconduitright)
                                    {
                                        pallapiazzata.GetComponent<Animator>().Play("load");
                                        pallacaricata.SetActive(true);
                                    }
                                    else if (scp)
                                    {

                                        text.text = "the script is wrong, try again";
                                    }
                                    else text.text = "nothing appened, insert a script";
                                }
                                else if (c1 != null && c1.CompareTag("palla"))
                                {
                                    Destroy(c1);
                                    c1 = null;
                                    space2 = null;
                                    pallapiazzata.SetActive(true);
                                    sceneInfo.inventory--;
                                    text.text = ("object placed");
                                    colliderpalla.SetActive(false);
                                    if (scriptconduitright)
                                    {
                                        pallapiazzata.GetComponent<Animator>().Play("load");
                                        pallacaricata.SetActive(true);
                                    }
                                    else if (scp)
                                    {

                                        text.text = "the script is wrong, try again";
                                    }
                                    else text.text = "nothing appened, insert a script";
                                }
                                else text.text = "no objects to place";


                            }
                            else text.text = "first place the cannon";
                        }
                        else text.text = "invenrtory is empty";
                        modified = true;
                        cnt = 0;
                        gaze.fillAmount = 0;
                    }
                    break;
                case "placecannon":
                    cnt += Time.deltaTime;
                    gaze.fillAmount = cnt / time;
                    if (gaze.fillAmount == 1)
                    {
                        if (sceneInfo.inventory > 0)
                        {
                            GameObject[] list = new GameObject[4];
                            if (c.CompareTag("cannon"))
                            {
                                list = Put(c, c1, space1, space2);
                                c = list[0];
                                c1 = list[1];
                                space1 = list[2];
                                space2 = list[3];
                                cannonepiazzato.SetActive(true);
                                text.text = ("object placed");
                                canplace = true;
                                collidercannone.SetActive(false);
                            }
                            else if (c1 != null && c1.CompareTag("cannon"))
                            {
                                Destroy(c1);
                                c1 = null;
                                space2 = null;
                                cannonepiazzato.SetActive(true);
                                sceneInfo.inventory--;
                                text.text = ("object placed");
                                canplace = true;
                                collidercannone.SetActive(false);
                            }
                            else text.text = "you need a cannon";
                           

                        }
                        else text.text = "inventory is empty";
                        modified = true;
                        cnt = 0;
                        gaze.fillAmount = 0;
                    }
                    break;
                case "cannon":
                    cnt += Time.deltaTime;
                    gaze.fillAmount=cnt/time;
                    if (gaze.fillAmount == 1)
                    {
                        if (sceneInfo.inventory < 2)
                        {
                            GameObject[] list = new GameObject[4];
                            list = Collect(objecthit.gameObject, c, c1, slot1, space1, space2);
                            c = list[0];
                            c1 = list[1];
                            space1 = list[2];
                            space2 = list[3];
                            objecthit.gameObject.SetActive(false);
                            text.text = ("object taken");
                            collidercannone.SetActive(true);
                        }
                        else text.text = "inventory is full";
                        modified = true;
                        cnt = 0;
                        gaze.fillAmount = 0;
                    }
                    break;
                case "palla":
                    cnt += Time.deltaTime;
                    gaze.fillAmount = cnt / time;
                    if (gaze.fillAmount == 1)
                    {
                        if (sceneInfo.inventory < 2)
                        {
                            GameObject[] list = new GameObject[4];
                            list = Collect(objecthit.gameObject, c, c1, slot1, space1, space2);
                            c = list[0];
                            c1 = list[1];
                            space1 = list[2];
                            space2 = list[3];
                          objecthit.gameObject.SetActive(false);
                            text.text = ("object taken");
                            colliderpalla.SetActive(true);
                        }
                        else text.text = "inventory is full";
                        modified = true;
                        cnt = 0;
                        gaze.fillAmount = 0;
                    }
                    break;
                case "save":
                    cnt += Time.deltaTime;
                    gaze.fillAmount = cnt / time;
                    if (gaze.fillAmount == 1)
                    {
                        if (sceneInfo.ismachine)
                        {
                            if ((s1 == "Condition= \"machine.getButton().isPressed()==true\"") || (s2 == "Condition= \"machine.getButton().isPressed()==true\""))
                                if ((s1== "Statement= \"machine,getGun().setShootingPower(200)\"") || (s2== "Statement= \"machine,getGun().setShootingPower(200)\""))
                            sceneInfo.rightM = true;
                            else sceneInfo.rightM = false;
                            sceneInfo.hasM = true;
                        }

                        else
                        {
                            if ((s1 == "Condition= \"conduit.objectPlaced()== true\"") || (s2 == "Condition= \"conduit.objectPlaced()== true\""))
                                if ((s1 == "Statement= \"conduit.Push(object)\"") || (s2 == "Statement= \"conduit.Push(object)\"")) 
                            sceneInfo.rightC = true;
                            else sceneInfo.rightC= false;
                            sceneInfo.hasC = true;
                        }
                        GameObject[] list= new GameObject[4];
                        list=Collect(GameObject.Find("conduitsheet"), c, c1, slot1, space1, space2);
                        c = list[0];
                        c1= list[1];
                        space1 = list[2];
                        space2 = list[3];
                        cnt = 0;
                        gaze.fillAmount = 0;
                     
                    
                    }
                    break;
                case "place":
                    if (sceneInfo.hasLadder)
                        cnt+= Time.deltaTime;
                    gaze.fillAmount= cnt / time;
                    if (gaze.fillAmount == 1)
                    {
                        if (sceneInfo.lunghezzascala == 3)
                        {
                            scala1.SetActive(true);
                            scala2.SetActive(true);
                            scala3.SetActive(true);
                        }
                        else if (sceneInfo.lunghezzascala == 2)
                        {

                            scala1.SetActive(true);
                            scala2.SetActive(true);
                        }
                        else scala1.SetActive(true);

                        sceneInfo.hasLadder = false;
                        GameObject.Find("triggerplace").SetActive(false);
                        cnt = 0;
                        gaze.fillAmount = 0;

                    }



                        break;
                case "machinesheet":
                    if (modified1 == false)
                    {
                        cnt += Time.deltaTime;
                        gaze.fillAmount = cnt / time;
                        if (gaze.fillAmount == 1)
                        {
                           
                            modified1 = true;
                           
                           
                            libro = Instantiate(Resources.Load("ifmachine"), imgmachine.transform.position, imgmachine.transform.rotation) as GameObject;
                            spot1 = GameObject.Find("condBool (4)");
                            spot2 = GameObject.Find("condBool (5)");
                            GetComponent<CharacterController>().minMoveDistance = 1000f;
                            sceneInfo.ismachine = true;
                            cnt = 0;
                            gaze.fillAmount = 0;
                        }
                    }
                    break;
                case "conduitsheet":
                    if (modified1 == false)
                    {
                        cnt += Time.deltaTime;
                        gaze.fillAmount = cnt / time;
                        if (gaze.fillAmount == 1)
                        {

                            modified1 = true;


                            libro = Instantiate(Resources.Load("ifconduit"), imgconduit.transform.position, imgconduit.transform.rotation) as GameObject;
                            spot1 = GameObject.Find("condBool (4)");
                            spot2 = GameObject.Find("condBool (5)");
                            GetComponent<CharacterController>().minMoveDistance = 1000f;
                            sceneInfo.ismachine = false;
                            cnt = 0;
                            gaze.fillAmount = 0;
                        }
                    }
                    break;
                case "book3":
                    if (modified1 == false)
                    {
                        cnt += Time.deltaTime;
                        gaze.fillAmount = cnt / time;
                        if (gaze.fillAmount == 1)
                        {
                            explored.SetAll(true);
                            modified1 = true;
                            // img.fillAmount = 1f;
                            cnt = 0;
                            gaze.fillAmount = 0;
                            libro = Instantiate(prefablibro3, img.transform.position, img.transform.rotation);
                            GetComponent<CharacterController>().minMoveDistance = 1000f;
                          
                        }
                    }
                    break;
                case "chest":

                    if (open4 == false)
                    {
                        cnt += Time.deltaTime;

                        gaze.fillAmount = cnt / time;
                       
                            
                            if (dist < 15)
                            {

                                if (gaze.fillAmount == 1)
                                {


                                    modified = true;
                                    objecthit.gameObject.GetComponent<Animator>().Play("openchest");
                                    cnt = 0;
                                    gaze.fillAmount = 0;
                                    open4 = true;


                                }




                            }
                        
                    }
                    break;
                case "height":
                    if (open4)
                    {
                        cnt += Time.deltaTime;
                        gaze.fillAmount = cnt / time;
                        if (gaze.fillAmount == 1)
                        {
                            //Destroy(objecthit.gameObject);
                            GameObject[] list = new GameObject[4];
                            list =Collect(objecthit.gameObject,c,c1,slot1,space1,space2);
                            c = list[0];
                            c1 = list[1];
                            space1 = list[2];
                            space2 = list[3];
                            objecthit.gameObject.SetActive(false);
                            text.text = ("variable taken");
                            modified = true;

                            cnt = 0;
                            gaze.fillAmount = 0;
                        }

                    }
                    break;
                case "reset":
                    if (dist < 15 && interacted == true)
                    {
                        cnt += Time.deltaTime;
                        gaze.fillAmount = cnt / time;
                        if (gaze.fillAmount == 1)
                        {

                            resetted = Instantiate(prefabcube, Pos, Rot);
                            resetted.GetComponentInChildren<TextMeshProUGUI>().text = pretext;
                            interacted = false;
                            cnt = 0;
                            gaze.fillAmount = 0;
                            text.text = "variables restored";
                            modified = true;
                        }
                    }

                    break;
                case "keyboard" :
                    if (modified1 == false)
                    {
                        cnt += Time.deltaTime;
                        // objecthit.gameObject.GetComponent<MeshRenderer>().material = mat;
                        gaze.fillAmount = cnt / time;
                        if (gaze.fillAmount == 1 && explored.Get(0) == true && explored.Get(1) == true)
                        {
                            sceneInfo.v = true;
                            cnt = 0;
                            gaze.fillAmount = 0;
                        }
                        else if (gaze.fillAmount == 1)
                        {
                            text.text = "Try to read some books first";
                            modified = true;
                            cnt = 0;
                            gaze.fillAmount = 0;
                        }
                    }
                    break;
                case "assigner":
                    if (dist < 15 && placed == false && sceneInfo.inventory > 0)
                    {
                        cnt += Time.deltaTime;
                        gaze.fillAmount = cnt / time;
                        if (gaze.fillAmount == 1)
                        {
                            
                            string namevar;
                            switch (space1.tag)
                            {
                                case "variabile":
                                    namevar = "variabile_chiave";
                                    pretext = space1.GetComponentInChildren<TextMeshProUGUI>().text;
                                    break;
                                case "key":
                                    namevar = "Simple_03";
                                    sceneInfo.hasKey = false;
                                    break;
                                case "ladder":
                                    namevar = "Ladder";
                                    sceneInfo.hasLadder = false;
                                    pretext = "ladder";
                                    break;
                                    case "height": namevar= "height";
                                    pretext = space1.GetComponentInChildren<TextMeshProUGUI>().text;
                                    break;
                                default:
                                    namevar = "variabile_chiave";
                                    break;
                            }
                            Vector3 ve = new Vector3(spawner.transform.position.x, spawner.transform.position.y + 0.5f, spawner.transform.position.z);
                            //tempDown = Instantiate(space1, ve, spawner.transform.rotation) as GameObject;
                            //tempDown.SetActive(true);
                            tempDown = Instantiate(Resources.Load<GameObject>(namevar), ve, spawner.transform.rotation);


                            GameObject[] list = new GameObject[4];
                            list = Put( c, c1,  space1, space2);
                            c = list[0];
                            c1 = list[1];
                            space1 = list[2];
                            space2 = list[3];

                            if (namevar== "variabile_chiave")
                            tempDown.GetComponentInChildren<TextMeshProUGUI>().text = pretext;
                            else if (namevar == "Ladder")
                            {
                                tempDown.gameObject.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
                                tempDown.gameObject.transform.position = new Vector3(tempDown.transform.position.x, tempDown.transform.position.y - 0.25f, tempDown.transform.position.z);
                            }
                            else if (namevar=="height")
                            {
                               // tempDown.gameObject.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
                                tempDown.gameObject.transform.position = new Vector3(tempDown.transform.position.x, tempDown.transform.position.y , tempDown.transform.position.z);
                                tempDown.gameObject.transform.rotation = new Quaternion(tempDown.transform.rotation.x, tempDown.transform.rotation.y +180, tempDown.transform.rotation.z-90 , tempDown.transform.rotation.w);
                            }

                            placed = true;
                            cnt = 0;
                            gaze.fillAmount = 0;
                            text.text = "ready to assign";
                            modified = true;
                            tagged1 = pretext;
                            sceneInfo.placed = true;
                        }
                    }
                    else if (dist < 15 && placed == true)
                    {
                        cnt += Time.deltaTime;
                        gaze.fillAmount = cnt / time;
                        if (gaze.fillAmount == 1)
                        {
                            if (sceneInfo.inventory < 2)
                            {
                                GameObject[] list = new GameObject[4];
                               list= Collect(tempDown,c, c1, slot1, space1, space2);
                                c = list[0];
                                c1 = list[1];
                                space1 = list[2];
                                space2 = list[3];
                                tempDown.SetActive(false);
                                tempDown = null;
                                
                               
                                tagged1 = "default";
                                cnt = 0;
                                gaze.fillAmount = 0;
                                text.text = "object obtained";
                                modified = true;
                                sceneInfo.placed = true;
                                placed = false;
                            }
                            else
                            {
                                cnt = 0;
                                gaze.fillAmount = 0;
                                text.text = "the inventory is full";
                                modified = true;
                            }
                        }
                    }

                    break;
                case "assignerUp":
                    if (dist < 15  && placed2 == false && sceneInfo.inventory > 0)
                    {
                        cnt += Time.deltaTime;
                        gaze.fillAmount = cnt / time;
                        if (gaze.fillAmount == 1 )
                        {
                           
                            string namevar;
                           switch (space1.tag)
                            {
                                case "variabile": namevar = "variabile_chiave";
                                    pretext = space1.GetComponentInChildren<TextMeshProUGUI>().text;
                                    break;
                                case "key": namevar = "Simple_03";
                                    sceneInfo.hasKey = false;
                                    break;
                                case "ladder":
                                    namevar = "Ladder";
                                    sceneInfo.hasLadder = false;
                                    pretext = "ladder";
                                    break;
                                case "height": namevar = "height";
                                    pretext = space1.GetComponentInChildren<TextMeshProUGUI>().text;
                                    break;
                                default: namevar = "variabile_chiave";
                                    break;
                            }
                            Vector3 ve = new Vector3(spawner.transform.position.x, spawner.transform.position.y + 1.5f, spawner.transform.position.z);
                            // tempUp=Instantiate(Resources.Load<GameObject>(namevar),ve,spawner.transform.rotation);
                            tempUp = Instantiate(Resources.Load<GameObject>(namevar), ve, spawner.transform.rotation);
                            //tempUp.SetActive(true);

                            GameObject[] list = new GameObject[4];
                            list = Put(c, c1, space1, space2);
                            c = list[0];
                            c1 = list[1];
                            space1 = list[2];
                            space2 = list[3];


                            if (namevar == "variabile_chiave")
                                tempUp.GetComponentInChildren<TextMeshProUGUI>().text = pretext;
                            else if (namevar == "Ladder")
                            {
                                tempUp.gameObject.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
                                tempUp.gameObject.transform.position = new Vector3(tempUp.transform.position.x, tempUp.transform.position.y - 0.25f, tempUp.transform.position.z);
                            }
                            else if (namevar == "height")
                            {
                               // tempUp.gameObject.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
                                tempUp.gameObject.transform.position = new Vector3(tempUp.transform.position.x, tempUp.transform.position.y , tempUp.transform.position.z);
                                tempUp.gameObject.transform.rotation = new Quaternion(tempUp.transform.rotation.x, tempUp.transform.rotation.y+180 , tempUp.transform.rotation.z-90, tempUp.transform.rotation.w);
                            }
                            sceneInfo.placed = true;
                            placed2 = true;
                            cnt = 0;
                            gaze.fillAmount = 0;
                            text.text = "ready to assign";
                            modified = true;
                            tagged = pretext;
                        }
                    }
                    else if (dist < 15 && placed2 == true && sceneInfo.inventory < 2)
                    {
                        cnt += Time.deltaTime;
                        gaze.fillAmount = cnt / time;
                        if (gaze.fillAmount == 1)
                        {
                            if (sceneInfo.inventory < 2)
                            {
                                GameObject[] list = new GameObject[4];
                               list= Collect(tempUp, c, c1, slot1, space1, space2);
                                c = list[0];
                                c1 = list[1];
                                space1 = list[2];
                                space2 = list[3];

                               tempUp.SetActive(false);
                                tempUp = null;

                               
                                tagged = "default";
                                cnt = 0;
                                gaze.fillAmount = 0;
                                text.text = "object obtained";
                                modified = true;
                                sceneInfo.placed = true;
                                placed2 = false;
                            }
                            else
                            {
                                cnt = 0;
                                gaze.fillAmount = 0;
                                text.text = "the inventory is full";
                                modified = true;
                            }
                        }
                    }

                    break;
                case "monitor":
                    if ( dist < 15 && open2 == false)
                    {
                        cnt += Time.deltaTime;
                        gaze.fillAmount = cnt / time;

                        if (gaze.fillAmount == 1)
                        {

                            objecthit.gameObject.GetComponent<Animator>().Play("MonitorOn");
                            open2 = true;
                            cnt = 0;
                            gaze.fillAmount = 0;

                        }



                    }

                   

                    break;              
                case "buttonKey":
                    if (dist < 15)//&& assigned == false && placed == true)
                    {
                        cnt += Time.deltaTime;
                        gaze.fillAmount = cnt / time;
                        if (gaze.fillAmount == 1)
                        {
                            switch (objecthit.gameObject.GetComponentInChildren<TextMeshProUGUI>().text)
                            {
                                case "Key k= new Key()":
                                    z = CheckObjectPosition("Key", tempUp, tempDown);
                                    switch (z)
                                    {
                                        case 0:
                                            text.text = "Object not found";

                                            break;
                                        case 1:
                                            tempUp = ReplaceObject(key, tempUp);
                                            tagged = tempUp.GetComponentInChildren<TextMeshProUGUI>().text;
                                            text.text = "object created";
                                            break;
                                        case 2:
                                            tempDown = ReplaceObject(key, tempDown);
                                            tagged1 = tempDown.GetComponentInChildren<TextMeshProUGUI>().text;
                                            text.text = "object created";
                                            break;
                                        default:
                                            text.text = "Lezzo";
                                            break;
                                    }
                                    break;


                                case "Ladder ladder = new Ladder()":

                                    z = CheckObjectPosition("Ladder", tempUp, tempDown);
                                    switch (z)
                                    {
                                        case 0:
                                            text.text = "Object not found";

                                            break;
                                        case 1:
                                            tempUp = ReplaceObject(ladder, tempUp);
                                            tempUp.gameObject.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
                                            tempUp.gameObject.transform.position = new Vector3(tempUp.transform.position.x, tempUp.transform.position.y - 0.25f, tempUp.transform.position.z);
                                            tagged = tempUp.GetComponentInChildren<TextMeshProUGUI>().text;
                                            text.text = "object created";
                                            break;
                                        case 2:
                                            tempDown = ReplaceObject(ladder, tempDown);
                                            tempDown.gameObject.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
                                            tempDown.gameObject.transform.position = new Vector3(tempDown.transform.position.x, tempDown.transform.position.y - 0.25f, tempDown.transform.position.z);
                                            tagged1 = tempDown.GetComponentInChildren<TextMeshProUGUI>().text;
                                            text.text = "object created";
                                            break;
                                        default:
                                            text.text = "Lezzo";
                                            break;
                                    }
                                    break;

                                case "ladder.SetHeight(var)":
                                    z = CheckObjectPosition("ladder", tempUp, tempDown);
                                    if (z == 0) text.text = "there is no ladder,/n assign the variable first";
                                    else
                                    {
                                        z = CheckObjectPosition("var", tempUp, tempDown);
                                        if (z == 0) text.text = "var value not found or null";
                                        else
                                        {
                                            switch (sceneInfo.var)
                                            {
                                                case 1:
                                                    sceneInfo.lunghezzascala = 1;

                                                    break;
                                                case 2:
                                                    sceneInfo.lunghezzascala = 2;

                                                    break;
                                                case 3:
                                                    sceneInfo.lunghezzascala = 3;

                                                    break;


                                            }
                                            text.text = "ladder changed";
                                        }
                                    }
                                    break;


                                case "Int var= window.GetHeight()": sceneInfo.var = 3;
                                    
                                    z = CheckObjectPosition("Int", tempUp, tempDown);
                                    switch (z)
                                    {
                                        case 0:
                                            text.text = "Object not found";

                                            break;
                                        case 1:

                                            tempUp.GetComponentInChildren<TextMeshProUGUI>().text = "var";
                                            text.text = "var=3";
                                            tagged = tempUp.GetComponentInChildren<TextMeshProUGUI>().text;
                                            break;
                                        case 2:
                                            tempDown.GetComponentInChildren<TextMeshProUGUI>().text = "var";
                                            tagged1 = tempDown.GetComponentInChildren<TextMeshProUGUI>().text;
                                            text.text = "var=3";
                                            break;
                                    }
                                    break;


                                case "Int var=1":
                                    sceneInfo.var = 1;
                                    z = CheckObjectPosition("Int", tempUp, tempDown);
                                    switch (z)
                                    {
                                        case 0:
                                            if (CheckObjectPosition("var",tempUp,tempDown)==0)
                                            text.text = "Object not found";
                                            else if (CheckObjectPosition("var", tempUp, tempDown) == 1) 
                                            {
                                                tempUp.GetComponentInChildren<TextMeshProUGUI>().text = "var";
                                                text.text = "var=1";
                                                tagged = tempUp.GetComponentInChildren<TextMeshProUGUI>().text;
                                            }else if (CheckObjectPosition("var", tempUp, tempDown) == 2)
                                            {
                                                tempDown.GetComponentInChildren<TextMeshProUGUI>().text = "var";
                                                text.text = "var=1";
                                                tagged1 = tempDown.GetComponentInChildren<TextMeshProUGUI>().text;
                                            }
                                            break;
                                        case 1:

                                            tempUp.GetComponentInChildren<TextMeshProUGUI>().text = "var";
                                            text.text = "var=1";
                                            tagged = tempUp.GetComponentInChildren<TextMeshProUGUI>().text;
                                            break;
                                        case 2:
                                            tempDown.GetComponentInChildren<TextMeshProUGUI>().text = "var";
                                            tagged1 = tempDown.GetComponentInChildren<TextMeshProUGUI>().text;
                                            text.text = "var=1";
                                            break;
                                    }
                                    break;



                                case "Int var=2":
                                    sceneInfo.var = 2;
                                    z = CheckObjectPosition("Int", tempUp, tempDown);
                                    switch (z)
                                    {
                                        case 0:
                                            if (CheckObjectPosition("var", tempUp, tempDown) == 0)
                                                text.text = "Object not found";
                                            else if (CheckObjectPosition("var", tempUp, tempDown) == 1)
                                            {
                                                tempUp.GetComponentInChildren<TextMeshProUGUI>().text = "var";
                                                text.text = "var=2";
                                                tagged = tempUp.GetComponentInChildren<TextMeshProUGUI>().text;
                                            }
                                            else if (CheckObjectPosition("var", tempUp, tempDown) == 2)
                                            {
                                                tempDown.GetComponentInChildren<TextMeshProUGUI>().text = "var";
                                                text.text = "var=2";
                                                tagged1 = tempDown.GetComponentInChildren<TextMeshProUGUI>().text;
                                            }
                                            break;
                                        case 1:

                                            tempUp.GetComponentInChildren<TextMeshProUGUI>().text = "var";
                                            text.text = "var=2";
                                            tagged = tempUp.GetComponentInChildren<TextMeshProUGUI>().text;
                                            break;
                                        case 2:
                                            tempDown.GetComponentInChildren<TextMeshProUGUI>().text = "var";
                                            tagged1 = tempDown.GetComponentInChildren<TextMeshProUGUI>().text;
                                            text.text = "var=2";
                                            break;
                                    }
                                    break;


                            }
                            cnt = 0;
                            gaze.fillAmount = 0;
                            sceneInfo.placed = true;
                            modified = true;
                            monitor.GetComponent<Animator>().Play("MonitorOff");
                            open2 = false;
                            
                           // tagged = "default";

                        }
                    }
                        break;
                case "door":
                    cnt += Time.deltaTime;
                    gaze.fillAmount = cnt / time;                 
                                          
                        if (dist < 15)
                        {
                       
                            if (open3 == false)
                            {
                                if (gaze.fillAmount == 1 && sceneInfo.hasKey == true)
                                {
                                openandclose1 = objecthit.gameObject.GetComponent<Animator>();
                                text.text = ("Key used");
                                    modified = true;
                                    StartCoroutine(opening3());
                                    cnt = 0;
                                    gaze.fillAmount = 0;
                                    sceneInfo.hasKey = false;

                                }
                                else if (gaze.fillAmount == 1 && sceneInfo.hasKey == false)
                                {
                                openandclose1 = objecthit.gameObject.GetComponent<Animator>();
                                text.text = ("Door is locked, find the key");
                                    modified = true;
                                    cnt = 0;
                                    gaze.fillAmount = 0;

                                }
                            }
                            else
                            {
                                if (open3 == true)
                                {
                                    if (gaze.fillAmount == 1)
                                    {

                                        StartCoroutine(closing3());
                                        cnt = 0;
                                        gaze.fillAmount = 0;
                                    }
                                }

                            }

                        }
                    
                    break;
                case "door1":
                    cnt += Time.deltaTime;
                    gaze.fillAmount = cnt / time;



                    if (dist < 15)
                    {
                        if (open == false)
                        {
                            if (gaze.fillAmount == 1)
                            {

                                StartCoroutine(opening());
                                StartCoroutine(opening2());
                                cnt = 0;
                                gaze.fillAmount = 0;
                            }
                        }
                        else
                        {
                            if (open == true)
                            {
                                if (gaze.fillAmount == 1)
                                {
                                    StartCoroutine(closing());
                                    StartCoroutine(closing2());
                                    cnt = 0;
                                    gaze.fillAmount = 0;
                                }
                            }

                        }

                    }

                    break;
                case "book1":
                    if (modified1 == false)
                    {
                        cnt += Time.deltaTime;
                        gaze.fillAmount = cnt / time;
                        if (gaze.fillAmount == 1)
                        {
                            explored.Set(1, true);
                            modified1 = true;
                            //img2.fillAmount = 1f;
                            cnt = 0;
                            gaze.fillAmount = 0;
                            libro = Instantiate(prefablibro2, img.transform.position, img.transform.rotation);
                            GetComponent<CharacterController>().minMoveDistance = 1000f;
                            invisible = GameObject.Find("invisible");
                            invisible.SetActive(false);
                        }

                    }
                    break;
                case "book":
                    if (modified1 == false)
                    {
                        cnt += Time.deltaTime;
                        gaze.fillAmount = cnt / time;
                        if (gaze.fillAmount == 1)
                        {
                            Debug.Log("esplorabili ++");
                            explored.Set(0, true);
                            modified1 = true;
                            //img2.fillAmount = 1f;
                            cnt = 0;
                            gaze.fillAmount = 0;
                            libro = Instantiate(prefablibro1, img.transform.position, img.transform.rotation);
                            GetComponent<CharacterController>().minMoveDistance = 1000f;
                            invisible = GameObject.Find("invisible");
                            invisible.SetActive(false);
                        }

                    }
                    break;
                case "close":
                    cnt += Time.deltaTime;
                    gaze.fillAmount = cnt / time;
                    if (gaze.fillAmount == 1)
                    {
                        Destroy(libro);
                        modified1 = false;
                        if (sceneInfo.actualscene == 1)
                        {
                            invisible.SetActive(true);
                            invisible = null;
                        }
                        GetComponent<CharacterController>().minMoveDistance = 0.001f;
                        sceneInfo.ismachine = false;
                        pieno = 0;
                        cnt = 0;
                        gaze.fillAmount = 0;

                    }
                    break;
                case "trash":
                    if (sceneInfo.inventory > 0)
                    {
                        cnt += Time.deltaTime;
                        gaze.fillAmount = cnt / time;
                        if (gaze.fillAmount == 1)
                        {
                            GameObject[] list = new GameObject[4];
                            list = Put(c, c1, space1, space2);
                            c = list[0];
                            c1 = list[1];
                            space1 = list[2];
                            space2 = list[3];
                            cnt = 0;
                            gaze.fillAmount = 0;
                        }
                    }
                    break;

                default:
                    if (cnt > 0 && layer != 9) cnt -= Time.deltaTime;
                    gaze.fillAmount = cnt / time;
                    // if (gaze.fillAmount == 0) { ogg.GetComponent<MeshRenderer>().material = ogmat; }
                    break;
            }
        }
        else
        {
            if (cnt > 0) cnt -= Time.deltaTime;
            gaze.fillAmount = cnt / time;
        }


        if (modified == true)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - 0.0005f);
        }
        if (text.color.a <= 0)
        {
            text.text = "";
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
            modified = false;
        }
        if (tagged == "default" && tagged1 == "default")
            sceneInfo.nn = true;
        else
        if (tagged == "default" || tagged1 == "default")
            sceneInfo.none = true;
        else
        {
            sceneInfo.nn = false;
            sceneInfo.none = false;
        }
        if (tagged == "ladder" || tagged1 == "ladder")
            sceneInfo.ladder = true;
        else sceneInfo.ladder = false;
        if (tagged == "Ladder" || tagged1 == "Ladder")
            sceneInfo.laddervar = true;
        else sceneInfo.laddervar = false;
        if (tagged == "Int" || tagged1 == "Int")
            sceneInfo.intin = true;
        else sceneInfo.intin = false;
        if (tagged == "var" || tagged1 == "var")
            sceneInfo.varint = true;
        else sceneInfo.varint = false;
        if (tagged == "Key" || tagged1 == "Key")
            sceneInfo.keyvar = true;
        else sceneInfo.keyvar = false;
        if (tagged == "key" || tagged1 == "key")
            sceneInfo.key = true;
        else sceneInfo.key = false;
        if (tagged == "Color" || tagged1 == "Color")
            sceneInfo.color = true;
        else sceneInfo.color = false;
        if (tagged == "Window" || tagged1 == "Window")
            sceneInfo.window = true;
        else sceneInfo.window = false;
        /* if ((tagged == "Ladder" && tagged1 == "Int") || (tagged1 == "Ladder" && tagged == "Int"))
         {
             ButtonRoutine(a1, "Ladder ladder = new Ladder()", "buttonKey");
             // ButtonRoutine(a2, "ladder.length(var)", "buttonKey");
             ButtonRoutine(a3, "Int var = 2", "buttonKey");
             ButtonRoutine(a4, "Int var = 1", "buttonKey");
             a2.gameObject.SetActive(false);
             a5.gameObject.SetActive(false);
             a6.gameObject.SetActive(false);
             a7.gameObject.SetActive(false);
             a8.gameObject.SetActive(false);
             a9.gameObject.SetActive(false);
             a10.gameObject.SetActive(false);
             a11.gameObject.SetActive(false);
             a12.gameObject.SetActive(false);
         }
         else if ((tagged == "ladder" && tagged1 == "var") || (tagged1 == "ladder" && tagged == "var")) {
             ButtonRoutine(a1, "ladder.length(var)", "buttonKey");
             // ButtonRoutine(a2, "ladder.length(var)", "buttonKey");
             ButtonRoutine(a3, "Int var = 2", "buttonKey");
             ButtonRoutine(a4, "Int var = 1", "buttonKey");
             a2.gameObject.SetActive(false);
             a5.gameObject.SetActive(false);
             a6.gameObject.SetActive(false);
             a7.gameObject.SetActive(false);
             a8.gameObject.SetActive(false);
             a9.gameObject.SetActive(false);
             a10.gameObject.SetActive(false);
             a11.gameObject.SetActive(false);
             a12.gameObject.SetActive(false);
         }
         else if ((tagged == "Ladder" || tagged1 == "Ladder"))//&& (tagged == "default" || tagged1 == "default"))
         {
             ButtonRoutine(a1, "Ladder ladder = new Ladder()", "buttonKey");
             a2.gameObject.SetActive(false);
             a3.gameObject.SetActive(false);
             a4.gameObject.SetActive(false);
             a5.gameObject.SetActive(false);
             a6.gameObject.SetActive(false);
             a7.gameObject.SetActive(false);
             a8.gameObject.SetActive(false);
             a9.gameObject.SetActive(false);
             a10.gameObject.SetActive(false);
             a11.gameObject.SetActive(false);
             a12.gameObject.SetActive(false);

         }
         else if ((tagged == "Int" || tagged1 == "Int") && (tagged == "Window" || tagged1 == "Window"))//&& tagged == "default" || tagged1 == "default")
         {
             ButtonRoutine(a3, "Int var = 2", "buttonKey");
             ButtonRoutine(a4, "Int var = 1", "buttonKey");
             ButtonRoutine(a1, "Int var = Window.height", "buttonKey");
             a2.gameObject.SetActive(false);

             a5.gameObject.SetActive(false);
             a6.gameObject.SetActive(false);
             a7.gameObject.SetActive(false);
             a8.gameObject.SetActive(false);
             a9.gameObject.SetActive(false);
             a10.gameObject.SetActive(false);
             a11.gameObject.SetActive(false);
             a12.gameObject.SetActive(false);
         }
         else if (tagged == "Int" || tagged1 == "Int")
         {
             ButtonRoutine(a3, "Int var = 2", "buttonKey");
             ButtonRoutine(a4, "Int var = 1", "buttonKey");
             a1.gameObject.SetActive(false);
             a2.gameObject.SetActive(false);

             a5.gameObject.SetActive(false);
             a6.gameObject.SetActive(false);
             a7.gameObject.SetActive(false);
             a8.gameObject.SetActive(false);
             a9.gameObject.SetActive(false);
             a10.gameObject.SetActive(false);
             a11.gameObject.SetActive(false);
             a12.gameObject.SetActive(false);
         }

             if ((tagged == "Key" && tagged1 == "Color" ) || (tagged1 == "Key" && tagged == "Color"))
         {
             ButtonRoutine(a1, "Key k= new Key();", "buttonKey");
             ButtonRoutine(a2, "k.MaterialColor(color)", "buttonKey");
             ButtonRoutine(a3, "Color color= new Color('Red')", "buttonKey");
             ButtonRoutine(a4, "Color color= new Color('Green')","buttonKey");
             a5.gameObject.SetActive(false);
             a6.gameObject.SetActive(false);
             a7.gameObject.SetActive(false);
             a8.gameObject.SetActive(false);
             a9.gameObject.SetActive(false);
             a10.gameObject.SetActive(false);
             a11.gameObject.SetActive(false);
             a12.gameObject.SetActive(false);
         }
          else
         if (tagged=="Color" || tagged1 == "Color")// && tagged == "default" || tagged1 == "default")
         {
             ButtonRoutine(a3, "Color color= new Color('Red')", "buttonKey");
             ButtonRoutine(a4, "Color color= new Color('Green')", "buttonKey");
             a1.gameObject.SetActive(false);
             a2.gameObject.SetActive(false);

             a5.gameObject.SetActive(false);
             a6.gameObject.SetActive(false);
             a7.gameObject.SetActive(false);
             a8.gameObject.SetActive(false);
             a9.gameObject.SetActive(false);
             a10.gameObject.SetActive(false);
             a11.gameObject.SetActive(false);
             a12.gameObject.SetActive(false);
         }
         else

         if (tagged == "Key" || tagged1 == "Key")// && tagged == "default" || tagged1 == "default")
         {
             ButtonRoutine(a1, "Key k= new Key();", "buttonKey");
             a2.gameObject.SetActive(false);
             a3.gameObject.SetActive(false);
             a4.gameObject.SetActive(false);
             a5.gameObject.SetActive(false);
             a6.gameObject.SetActive(false);
             a7.gameObject.SetActive(false);
             a8.gameObject.SetActive(false);
             a9.gameObject.SetActive(false);
             a10.gameObject.SetActive(false);
             a11.gameObject.SetActive(false);
             a12.gameObject.SetActive(false);
         }

         if (tagged == "default" && tagged1 == "default")
         {
             a1.gameObject.SetActive(false);
             a2.gameObject.SetActive(false);
             a3.gameObject.SetActive(false);
             a4.gameObject.SetActive(false);
             a5.gameObject.SetActive(false);
             a6.gameObject.SetActive(false);
             a7.gameObject.SetActive(false);
             a8.gameObject.SetActive(false);
             a9.gameObject.SetActive(false);                
             a10.gameObject.SetActive(false);
             a11.gameObject.SetActive(false);
             a12.gameObject.SetActive(false);              

         }
        */
        /*
        switch (tagged)
        {
            case ("Key"):
                ButtonRoutine(a1, "Key var= new Key()", "buttonKey");

                break;
            case ("Ladder"):
                ButtonRoutine(a1, "Ladder ladder = new Ladder(1)", "buttonKey");
                if (tagged1 == "Int") ButtonRoutine(a2, "ladder.length(var)", "buttonKey");
                if (tagged1 =="Color") ButtonRoutine(a3, "ladder.color(color)", "buttonKey");
                break;
            case ("Int"):
                ButtonRoutine(a1, "Int var= 2", "buttonKey");
                break;
            default:
               a1.gameObject.SetActive(false);
                a2.gameObject.SetActive(false);

                break;
        }
        */

        /*-------------------------------------------------------------------------------
         * -------------------------------------------------------------------------------
         * -----------------------------------------------------------------------------*/

        //-------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------//
        //-------------------------------CHARACTER CONTROLLER------------------------------//

        isGrounded = Physics.CheckSphere(groundCheckTransform.position, 0.3f, playerMask);

        if (isGrounded && velocity.y < 0) { velocity.y = -2f; }
        //isWalking = animator.GetBool("isWalking");
        if (!isWalking && Input.GetKey("w"))
        {
            //   animator.SetBool("isWalking", true);
        }
        if (isWalking && !Input.GetKey("w")) //animator.SetBool("isWalking", false);



            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                jumpKeyWasPressed = true;
                velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);


            }
            else jumpKeyWasPressed = false;

        //animator.SetBool("jumps", jumpKeyWasPressed);

        horizInput = Input.GetAxis("Horizontal");
        vertinput = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizInput + transform.forward * vertinput;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

   



    IEnumerator opening()
    {

        print("you are opening the door");
        cabinanimatordx.Play("OpenInverse");
        open = true;
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator closing()
    {
        print("you are closing the door");
        cabinanimatordx.Play("CloseInverse");
        open = false;
        yield return new WaitForSeconds(.5f);
    }
    IEnumerator opening2()
    {

        print("you are opening the door");
        cabinanimatorsx.Play("Opencab");
        open = true;
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator closing2()
    {
        print("you are closing the door");
        cabinanimatorsx.Play("closecabinet");
        open = false;
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator opening3()
    {
        print("you are opening the door");
        openandclose1.Play("Opening 1");
        open3 = true;
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator closing3()
    {
        print("you are closing the door");
        openandclose1.Play("Closing 1");
        open3 = false;
        yield return new WaitForSeconds(.5f);
    }
    static int CheckObjectPosition(string name,GameObject tempUp,GameObject tempDown)
    {
        int x = 0;
       x= (tempDown != null && tempDown.GetComponentInChildren<TextMeshProUGUI>().text == name)? 2:0;
        x = (tempUp != null && tempUp.GetComponentInChildren<TextMeshProUGUI>().text == name) ? 1 : x;
        return x;
    }

    static GameObject ReplaceObject(GameObject rimpiazzo, GameObject darimpiazzare)
    {
        GameObject oggetto;
        Vector3 a = darimpiazzare.transform.position;
        Quaternion b = darimpiazzare.transform.rotation;
        Destroy(darimpiazzare);
        oggetto = Instantiate(rimpiazzo, a, b);
        return oggetto;

    }
    static void ButtonRoutine(Button b,string text,string name)
    {
        b.GetComponent<TextMeshProUGUI>().text = (text);
        b.tag = name;
        b.gameObject.SetActive(true);
    }

    public GameObject[] Collect( GameObject go,GameObject c, GameObject c1, Transform slot1,GameObject space1,GameObject space2)
    {
        space1 = (sceneInfo.inventory == 0) ? go : space1;
        space2 = (sceneInfo.inventory == 1) ? go : space2;
        

       
        string namevar;
        switch (space1.tag)
        {
            case "variabile":
                namevar = "variabile_chiave";
                break;
            case "key":
                namevar = "Simple_03";
                sceneInfo.hasKey = true;
                break;
            case "ladder": namevar = "Ladder";
                sceneInfo.hasLadder = true;
                break;
            case "height":
                namevar = "height";
                break;
            case "conduitsheet":
                namevar = "preconduit";
                break;
            case "palla":
                namevar = "palla";
                break;
            case "cannon":
                namevar = "cannone";
                break;
            default:
                namevar = "";
                break;
        }
        string pretext=null;
       // if (namevar=="variabile_chiave")
         pretext = space1.GetComponentInChildren<TextMeshProUGUI>().text;


        if (c == null)
        {
            c = Instantiate(Resources.Load(namevar), slot1.position, slot1.rotation, slot1.parent) as GameObject;
          //  c.transform.localScale = slot1.localScale / 2f;
            
            c.transform.position = new Vector3(c.transform.position.x, c.transform.position.y +10, c.transform.position.z);
            c = Adjust(c, slot1,pretext);
            c.transform.parent = slot1;
            //  c.GetComponentInChildren<TextMeshProUGUI>().text = pretext;
        }else 
        if (space2 != null)
        {
            
            string namevar1;
            switch (space2.tag)
            {
                case "variabile":
                    namevar1 = "variabile_chiave";
                    break;
                case "key":
                    namevar1 = "Simple_03";
                    sceneInfo.hasKey = true;
                    break;
                case "ladder":
                    namevar1 = "Ladder";
                    sceneInfo.hasLadder = true;
                    break;
                case "height":
                    namevar1 = "height";
                    break;
                case "conduitsheet":
                    namevar1 = "preconduit";
                    break;
                case "palla":
                    namevar1 = "palla";
                    break;
                case "cannon":
                    namevar1 = "cannone";
                    break;
                default:
                    namevar1 = "";
                    break;
            }
            string pretext1=null;
           // if (namevar1 == "variabile_chiave")
                pretext1 = space2.GetComponentInChildren<TextMeshProUGUI>().text;

            c1 = Instantiate(Resources.Load(namevar1), slot1.position, slot1.rotation, slot1.parent) as GameObject;
           // c1.transform.localScale = slot1.localScale / 2f;
            
            c1.transform.position = new Vector3(c1.transform.position.x, c1.transform.position.y - 30, c1.transform.position.z);
            //c1.GetComponentInChildren<TextMeshProUGUI>().text = pretext1;
          
            c1 = Adjust(c1, slot1,pretext1);
            c1.transform.parent = slot1;
        }



        

        GameObject[] list = new GameObject[4];
        list[0] = c;
        list[1] = c1;
        list[2] = space1;
        list[3] = space2;
        sceneInfo.inventory++;
        return list;
    }

    public GameObject Adjust(GameObject o, Transform slot1, string pretext1)
    {
        if (o == null) return null;
        switch (o.tag)
        {
            case "key": o.transform.localScale = slot1.localScale * 7f;
                break;
            case "variabile":
                o.transform.localScale = slot1.localScale / 2f;
                o.GetComponentInChildren<TextMeshProUGUI>().text = pretext1;
                break;
            case "ladder":
                o.transform.localScale = slot1.localScale /5.5f;
                o.transform.position = new Vector3 (o.transform.position.x, o.transform.position.y-10, o.transform.position.z);
                break;
            case "height":
                GameObject i = GameObject.Find("height");
                o.transform.rotation = i.transform.rotation;
                o.transform.localScale = i.transform.localScale*130;
                //o.transform.position = i.transform.position;

                break;
            case "conduitsheet":
                GameObject e = GameObject.Find("height");
                o.transform.rotation = e.transform.rotation;
                o.transform.localScale = e.transform.localScale * 130;
                break;
            case "palla":
                
                o.transform.rotation = palla.transform.rotation;
                o.transform.localScale = palla.transform.localScale * 520;
                break;
            case "cannon":
                
               // o.transform.rotation = y.transform.rotation;
                o.transform.localScale = cannone.transform.localScale *300;
                break;
            default:
                o.transform.localScale = slot1.localScale ;
                break;
        }

        return o;
    }
     public GameObject[] Put(GameObject c, GameObject c1,GameObject space1, GameObject space2)
    {

        GameObject[] list = new GameObject[4];

        space1 = (sceneInfo.inventory == 2) ? space2 : null;
        space2 = null;


        if (sceneInfo.inventory == 2)
        {
            c1.transform.position = c.transform.position;
            Destroy(c);
            c = c1;
            c1 = null;
            
            
        }
        else
        {
            
            Destroy(c1);
            c1 = null;
            Destroy(c);
            c = null;

        }
        sceneInfo.inventory--;

        list[0] = c;
        list[1] = c1;
        list[2] = space1;
        list[3] = space2;
        return list;
    }


    
}


