using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionBrewingPot : MonoBehaviour
{
    public int id;
    public SpriteRenderer potionColour;
    public SpriteRenderer potionEffect;
    public Animator potionEffectAnimator;
    private BoxCollider boxCollider;

    public SpriteLoadingScript spriteLoadingScript;
    public SpriteRenderer loadingPotionColour;
    public SpriteRenderer loadingPotionEffect;
    public Animator loadingPotionEffectAnimator;

    public Animator couldronAnimator;

    private AssetsManager assetManager;

    private float maxbrewingTime = 0f;
    private float brewingTime = 0f; public float getBrewingTime() { return brewingTime; }
    public void setBrewingTime(float t) { brewingTime = t; maxbrewingTime = t; }//set current and max values

    private PotionData currentPotion; public PotionData getCurrentPotion() { return currentPotion; }


    // Start is called before the first frame update
    void Start()
    {
        currentPotion = new PotionData();
        couldronAnimator = gameObject.GetComponent<Animator>();
        assetManager = GameObject.Find("AssetManager").GetComponent<AssetsManager>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (brewingTime > 0f)//if timer is running?
        {
            brewingTime -= Time.deltaTime;

            if (brewingTime <= 0f)//if brewing has finished?
            {
                brewingTime = 0f;
                boxCollider.enabled = true;
                updateCauldronVisuals();
                couldronAnimator.SetInteger("Brweing", 0);
                Debug.Log("Cauldron ID: " + id);
            }
            else
            {
                boxCollider.enabled = false;
            }

            //spriteLoadingScript.setLoadVal((1f / maxbrewingTime) * brewingTime);
        }
    }

    public void updateCauldronVisuals()
    {
        potionColour.sprite = assetManager.findColourSprite(currentPotion.getRed(), currentPotion.getBlue(), currentPotion.getYellow());
        //potionEffect.sprite = assetManager.findEffectSprite(currentPotion.getEffectID());
        potionEffect.color = assetManager.colourPotionEffects(currentPotion.getRed(), currentPotion.getBlue(), currentPotion.getYellow());
        updatePotionEffect(potionEffectAnimator);
    }

    public void updatePotionEffect(Animator anim)
    {
        anim.SetInteger("Effect", currentPotion.getEffectID());
    }

    public void clearPotion()
    {
        currentPotion.setBlue(false);
        currentPotion.setRed(false);
        currentPotion.setYellow(false);
        currentPotion.setEffectID(0);
        updateCauldronVisuals();
    }


}
