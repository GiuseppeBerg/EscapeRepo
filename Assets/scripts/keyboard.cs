using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keyboard : MonoBehaviour
{
    public sceneInfo sceneInfo;
    public GameObject cam,o;
    private void Start()
    {
     cam = GameObject.Find("Main Camera");
     o = GameObject.Find("Giocatore");
        sceneInfo.v = false;
}
    private void Update()
   
    {
        if (sceneInfo.v == true)
        {
            o.SetActive(false);
            o.transform.position = new Vector3(-352.88f, -2.893f, 8.20205f);
            if (sceneInfo.actualscene==3)
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y-0.8f, cam.transform.position.z);
            o.SetActive(true);
            sceneInfo.v = false;
            sceneInfo.actualscene = 2;
            sceneInfo.changed = true;
            SceneManager.LoadScene("scena2");
           
            
        }
    }
}

