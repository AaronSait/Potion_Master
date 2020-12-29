using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssetsManager : MonoBehaviour
{
    public Sprite potionCol_Yellow;
    public Sprite potionCol_Red;
    public Sprite potionCol_Blue;

    public Sprite potionCol_Green;
    public Sprite potionCol_Purple;
    public Sprite potionCol_Orange;

    public Sprite potionCol_All;
    public Sprite potionCol_None;

    public Sprite potionEfct_Bubbles;
    public Sprite potionEfct_Swirls;
    public Sprite potionEfct_Sparks;
    public Sprite transparent;

    public Sprite normalCustmer;
    public Sprite happyCustomer;
    public Sprite sadCustomer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Sprite findColourSprite(bool r, bool b, bool y)
    {
        if (r && !b && !y)
        {
            return potionCol_Red;
        }
        else if (!r && b && !y)
        {
            return potionCol_Blue;
        }
        else if (!r && !b && y)
        {
            return potionCol_Yellow;
        }
        else if (r && b && !y)
        {
            return potionCol_Purple;
        }
        else if (!r && b && y)
        {
            return potionCol_Green;
        }
        else if (r && !b && y)
        {
            return potionCol_Orange;
        }
        else if (r && b && y)
        {
            return potionCol_All;
        }

        return potionCol_None;
    }

    public Color colourPotionEffects(bool r, bool b, bool y)
    {
        return new Color(0f, 0f, 0f);//black
        if (r && !b && !y)//red
        {
            return new Color(1f, 0, 0);//red
        }
        else if (!r && b && !y)//blue
        {
            return new Color(0, 0, 1f);//blue
        }
        else if (!r && !b && y)//yellow
        {
            return new Color(1f, 1f, 0);//yellow
        }
        else if (r && b && !y)//purple
        {
            return new Color(1f, 0, 1f);//purple
        }
        else if (!r && b && y)//green
        {
            return new Color(0, 1f, 0);//green
        }
        else if (r && !b && y)//orange
        {
            return new Color(1f, 0.7f, 0);//orange
        }
        else if (r && b && y)//white
        {
            return new Color(0f, 0f, 0f);//black
        }

        return new Color(0, 0, 0, 1);
    }

    public Sprite findEffectSprite(int effect)
    {
        Debug.Log("ef: " + effect);
        switch (effect)
        {
            case MixAlgorithums.EFFECT_BUBBLES:
                return potionEfct_Bubbles;

            case MixAlgorithums.EFFECT_SWIRLS:
                return potionEfct_Swirls;

            case MixAlgorithums.EFFECT_SPARKS:
                return potionEfct_Sparks;

            default://EFFECT_NONE
                return transparent;
        }
    }
}
