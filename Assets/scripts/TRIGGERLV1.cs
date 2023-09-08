using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TRIGGERLV1 : MonoBehaviour
{
    public sceneInfo sceneInfo;
    GameObject player, camera;
    // Start is called before the first frame update

    private void Awake()
    {
        player = GameObject.Find("Giocatore");
        camera = GameObject.Find("Main Camera");
    }
    private void OnTriggerEnter(Collider other)
    {
        sceneInfo.changed = true;
        sceneInfo.actualscene = 3;
        sceneInfo.lvpassed = true;
        player.SetActive(false);
        player.transform.position = new Vector3(-330.28f, -6.23f, 21.13f);
        camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y+0.8f, camera.transform.position.z);
        player.SetActive(true);
        


        SceneManager.LoadScene("scene3");
       
    }
}
