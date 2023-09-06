using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "sceneInfo", menuName = "persistence")]
public class sceneInfo : ScriptableObject
{
    public bool isnextscene = true;
    public bool hasKey=false;
    public int scene;
    public int inventory = 0;
    public GameObject inventoryObject, inventoryObject2 ;
    public bool hasLadder = false;
    public int actualscene = 1;
    public bool v,changed = false;
    private void OnEnable()
    {
        isnextscene = false;
        actualscene = 1;
        changed = false;
        v= false;
    }
}
