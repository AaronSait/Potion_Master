using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngreediantData : MonoBehaviour
{
    // Start is called before the first frame update
    public bool red = false, yellow = false, blue = false;
    public int effect = 0;
    //0- none, 1-bubble, 2-swerl, 3- spark
    PotionData potion;
    Vector3 startPos;
    GameObject culdren;
    bool couldren;
    
    private void Start()
    {
        startPos = transform.position;
        potion = new PotionData();

        if (red)
            potion.setRed(true);
        else if (blue)
            potion.setBlue(true);
        else if (yellow)
            potion.setYellow(true);

        potion.setEffectID(effect);
    }
    public void checkLocation()
    {
        if (couldren)
        {
            MixAlgorithums.addPotion(culdren.GetComponent<PotionBrewingPot>(), potion);
            //Debug.Log("HIT Couldren");
            //Debug.Log("Blue " + culdren.GetComponent<PotionBrewingPot>().getCurrentPotion().getBlue());
            //Debug.Log("red " + culdren.GetComponent<PotionBrewingPot>().getCurrentPotion().getRed());
            //Debug.Log("yellow " + culdren.GetComponent<PotionBrewingPot>().getCurrentPotion().getYellow());
            //Debug.Log("effect " + culdren.GetComponent<PotionBrewingPot>().getCurrentPotion().getEffectID());
            transform.position = startPos;
            couldren = false;
        }
        else
        {
            transform.position = startPos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Culdren")
        {
            couldren = true;
            culdren = other.transform.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        couldren = false;
        culdren = null;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Culdren")
        {
            couldren = true;
            culdren = other.transform.gameObject;
        }
    }
}
