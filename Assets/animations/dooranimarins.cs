using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SojaExiles

{
    public class dooranimarins : MonoBehaviour
    {

        public Animator openandclose1;
        public bool open;
        public Transform Player;
        public Image gaze;

        void Start()
        {
            open = false;
        }

        void Update()
        {
            {
                if (Player)
                {
                    float dist = Vector3.Distance(Player.position, transform.position);
                    if (dist < 15)
                    {
                        if (open == false)
                        {
                            if (gaze.fillAmount==1)
                            {
                                StartCoroutine(opening());
                            }
                        }
                        else
                        {
                            if (open == true)
                            {
                                if (gaze.fillAmount == 1)
                                {
                                    StartCoroutine(closing());
                                }
                            }

                        }

                    }
                }

            }

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
}
