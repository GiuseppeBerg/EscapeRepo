using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "sceneInfo", menuName = "persistence")]
public class sceneInfo : ScriptableObject
{
    public bool isnextscene = true;
    public bool hasKey=false;
    public int scene,lunghezzascala;
    public int inventory = 0;
    public GameObject inventoryObject, inventoryObject2 ;
    public bool hasLadder = false;
    public int actualscene = 1;
    public bool v,changed,lvpassed = false;
    private void OnEnable()
    {
        isnextscene = false;
        actualscene = 1;
        scene = 1;
        inventory = 0;
        changed = false;
        v= false;
        lvpassed = false;
    }
}
