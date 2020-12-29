using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PotionDraging : MonoBehaviour
{

     GameObject selected;
    public GameObject ReadyPotion;
    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        Touch[] touches = Input.touches;

        for (int i = 0; i < touches.Length; i++)
        {
            Ray ray = Camera.main.ScreenPointToRay(touches[i].position);
            RaycastHit rayHit;
            switch (touches[i].phase)
            {
                case TouchPhase.Began:
                   // Debug.Log("Began");
                    if (Physics.Raycast(ray, out rayHit))
                    {
                        selected = null;
                        //Debug.Log("HIT Something");
                        selected = rayHit.transform.gameObject;//.GetComponent< SpriteRenderer>();
                        if (selected.tag == "Culdren")
                        {
                            ReadyPotion.GetComponent<SetupPotionDrag>().setPotionDrag(selected.GetComponent<PotionBrewingPot>());
                            selected.GetComponent<PotionBrewingPot>().clearPotion();
                            selected = ReadyPotion;
                        }
                        if (selected.tag != "Ingreediants" && selected.tag != "finishedPotion")
                        {
                      //      Debug.Log("HIT Ingreediant");
                            selected = null;
                        }

                    }
                    break;
                case TouchPhase.Moved:
                    //Debug.Log("Moving Ingreediant");
                    Vector2 GRR = touches[i].position;
                    Vector3 tempVec = new Vector3(GRR.x, GRR.y, 10);
                    //tempVec = Camera.main.ScreenToWorldPoint(tempVec);
                    tempVec = Camera.main.ScreenToWorldPoint(tempVec);
                   // Debug.Log(tempVec);
                    //Vector3 tempVec = Camera.main.ScreenToWorldPoint(new Vector3(touches[i].position.x, touches[i].position.y, 0));
                    tempVec.z = 10;
                    if ( selected != null)
                        selected.transform.position = tempVec;
                    break;
                case TouchPhase.Ended:
                    // Debug.Log("Droped Ingreediant");
                    if (selected != null)
                    {
                        if(selected.GetComponent<IngreediantData>() != null)
                            selected.GetComponent<IngreediantData>().checkLocation();
                        else if (selected.GetComponent<FinishedPotion>() != null)
                            selected.GetComponent<FinishedPotion>().checkLocation();
                    }
                    selected = null;
                    break;
            }
        }
    }
}
/*
 * 1) take potion brwing pot and set up potion drag run setup potion drag with potion pot.
 * 2) dropoed on customer
 * 3) run customers give potions with potion data form potion drag 
 * 4) setup potion drag.clear
 */ 
