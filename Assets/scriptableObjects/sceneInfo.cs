using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "sceneInfo", menuName = "persistence")]
public class sceneInfo : ScriptableObject
{
    public bool isnextscene = true;
    public bool hasKey=false;
    public int scene, lunghezzascala, var;
    public int inventory = 0;
    public GameObject inventoryObject, inventoryObject2 ;
    public bool hasLadder = false;
    public int actualscene = 1;
    public bool v,changed,lvpassed,laddervar,ladder,varint,intin,keyvar,key,color,none,window,placed,nn = false;
    private void OnEnable()
    {
        isnextscene = false;
        actualscene = 1;
        scene = 1;
        inventory = 0;
        changed = false;
        v= false;
        lvpassed = false;
        var = 0;
        hasKey = false;
        hasLadder = false;
        lunghezzascala = 0;
    }
}
