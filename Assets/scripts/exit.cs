using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exit : MonoBehaviour
{
    public string sceneName;
    public bool isnextscene = true;
    [SerializeField] public sceneInfo sceneinfo;
    public GameObject player,camera;

    private void Awake()
    {
        player = GameObject.Find("Giocatore");
        camera = GameObject.Find("Main Camera");
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (sceneinfo.scene)
        {
            case (1):
                player.SetActive(false);
                player.transform.position = new Vector3(-402.67f, 658.8f, 10.07f);
                camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y , camera.transform.position.z);
                player.SetActive(true);
                sceneinfo.changed = true;
                SceneManager.LoadScene("scena1");
                sceneinfo.actualscene = 1;
                break;
            case (3):
                player.SetActive(false);
                 player.transform.position = new Vector3(-330.28f, -6.23f, 21.13f);
                camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y+1, camera.transform.position.z);
                player.SetActive(true);
                sceneinfo.changed = true;
                SceneManager.LoadScene("scene3");
                sceneinfo.actualscene = 3;
                
                break;
        }
        
    }
}
