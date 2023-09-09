using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class buttons : MonoBehaviour
{
    private Button a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12;
    public sceneInfo sceneInfo;

    // Start is called before the first frame update
    private void Awake()
    {
        a1 = GameObject.Find("Button").GetComponent<Button>();
        a2 = GameObject.Find("Button (1)").GetComponent<Button>();
        a3 = GameObject.Find("Button (2)").GetComponent<Button>();
        a4 = GameObject.Find("Button (4)").GetComponent<Button>();
        a5 = GameObject.Find("Button (5)").GetComponent<Button>();
        a6 = GameObject.Find("Button (6)").GetComponent<Button>();
        a7 = GameObject.Find("Button (8)").GetComponent<Button>();
        a8 = GameObject.Find("Button (10)").GetComponent<Button>();
        a9 = GameObject.Find("Button (12)").GetComponent<Button>();
        a10 = GameObject.Find("Button (9)").GetComponent<Button>();
        a11 = GameObject.Find("Button (11)").GetComponent<Button>();
        a12 = GameObject.Find("Button (13)").GetComponent<Button>();
        

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

    // Update is called once per frame
    void Update()
    {
        if (sceneInfo.placed)
        {
            if (sceneInfo.laddervar && sceneInfo.none)
            {
                ButtonRoutine(a1, "Ladder ladder = new Ladder()","buttonKey");
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
                
            }else
            if (sceneInfo.laddervar) ButtonRoutine(a1, "Ladder ladder = new Ladder()", "buttonKey");

            if (sceneInfo.intin && sceneInfo.none)
            {
                a1.gameObject.SetActive(false);
                a2.gameObject.SetActive(false);
                a3.gameObject.SetActive(false);
                ButtonRoutine(a5, "Int var=2", "buttonKey");
                ButtonRoutine(a4, "Int var=1", "buttonKey");
                a6.gameObject.SetActive(false);
                a7.gameObject.SetActive(false);
                a8.gameObject.SetActive(false);
                a9.gameObject.SetActive(false);
                a10.gameObject.SetActive(false);
                a11.gameObject.SetActive(false);
                a12.gameObject.SetActive(false);

            }
            else
           if (sceneInfo.varint)
            {
                ButtonRoutine(a5, "Int var=2", "buttonKey");
                ButtonRoutine(a4, "Int var=1", "buttonKey");
            }

            if (sceneInfo.varint && sceneInfo.none)
            {
                a1.gameObject.SetActive(false);
                a2.gameObject.SetActive(false);
                a3.gameObject.SetActive(false);
                ButtonRoutine(a5, "Int var=2", "buttonKey");
                ButtonRoutine(a4, "Int var=1", "buttonKey");
                a6.gameObject.SetActive(false);
                a7.gameObject.SetActive(false);
                a8.gameObject.SetActive(false);
                a9.gameObject.SetActive(false);
                a10.gameObject.SetActive(false);
                a11.gameObject.SetActive(false);
                a12.gameObject.SetActive(false);

            }
            else
          if (sceneInfo.intin)
            {
                ButtonRoutine(a5, "Int var=2", "buttonKey");
                ButtonRoutine(a4, "Int var=1", "buttonKey");
            }
            if (sceneInfo.keyvar && sceneInfo.none)
            {
                ButtonRoutine(a1, "Key k= new Key()", "buttonKey");
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
            else
           if (sceneInfo.keyvar) ButtonRoutine(a2, "Key k= new Key()", "buttonKey");

            if (sceneInfo.key && sceneInfo.none)
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
            else
           if (sceneInfo.key && sceneInfo.color) ButtonRoutine(a3, "key.SetColor(color)", "buttonKey");            
            

            if (sceneInfo.ladder && sceneInfo.varint) ButtonRoutine(a3, "ladder.SetHeight(var)", "buttonKey");
            else if (sceneInfo.ladder && sceneInfo.none)
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
           
            if (sceneInfo.window && (sceneInfo.varint || sceneInfo.intin)) ButtonRoutine(a3, "Int var= window.GetHeight()","buttonKey");
           else if (sceneInfo.window && sceneInfo.none)
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


            sceneInfo.placed = false;
        }
    }

    static void ButtonRoutine(Button b, string text, string name)
    {
        b.GetComponent<TextMeshProUGUI>().text = (text);
        b.tag = name;
        b.gameObject.SetActive(true);
    }
}
