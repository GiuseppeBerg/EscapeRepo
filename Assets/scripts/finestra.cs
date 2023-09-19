using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finestra : MonoBehaviour
{
    public GameObject f;
    public bool a;
    // Start is called before the first frame update

    private void Awake()
    {
        f = GameObject.Find("Window");
        a = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        a = true;
           
    }

    private void Update()
    {
        if (a) {
            f.GetComponent<BreakableWindow>().breakWindow();
            a = false;
            }
    }
}
