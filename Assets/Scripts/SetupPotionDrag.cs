using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupPotionDrag : MonoBehaviour
{
    private PotionData potionData; public PotionData getPotionData() { return potionData; }
    private SpriteRenderer colourSpRend;
    public SpriteRenderer effectSpRend;
    public Animator effectAnimator;

    private AssetsManager assetManager;

    // Start is called before the first frame update
    void Start()
    {
        assetManager = GameObject.Find("AssetManager").GetComponent<AssetsManager>();
        colourSpRend = gameObject.GetComponent<SpriteRenderer>();
        potionData = new PotionData();
    }

    public void setPotionDrag(PotionBrewingPot pbp)
    {
        //potionData = pbp.getCurrentPotion();//pass by reference
        potionData.setRed(pbp.getCurrentPotion().getRed());
        potionData.setBlue(pbp.getCurrentPotion().getBlue());
        potionData.setYellow(pbp.getCurrentPotion().getYellow());
        potionData.setEffectID(pbp.getCurrentPotion().getEffectID());

        colourSpRend.sprite = assetManager.findColourSprite(potionData.getRed(), potionData.getBlue(), potionData.getYellow());
        effectSpRend.color = assetManager.colourPotionEffects(potionData.getRed(), potionData.getBlue(), potionData.getYellow());
        effectAnimator.SetInteger("Effect", potionData.getEffectID());
    }

    public void clear()
    {
        colourSpRend.sprite = assetManager.potionCol_None;
        effectAnimator.SetInteger("Effect", 0);
        potionData.clear();
    }

}
