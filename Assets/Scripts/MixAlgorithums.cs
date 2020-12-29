
public class MixAlgorithums
{
    public const int EFFECT_NONE = 0;
    public const int EFFECT_BUBBLES = 1;
    public const int EFFECT_SWIRLS = 2;
    public const int EFFECT_SPARKS = 3;

    static public void addPotion(PotionBrewingPot pBPot, PotionData pData)
    {
        if (pBPot.getBrewingTime() <= 0f)//if the potion can have a new potion added to it?
        {
            //if there's nothing in the pot?
            if (!pBPot.getCurrentPotion().getRed() && !pBPot.getCurrentPotion().getBlue() && !pBPot.getCurrentPotion().getYellow()
                && pBPot.getCurrentPotion().getEffectID() == EFFECT_NONE)
            {
                pBPot.setBrewingTime(0.1f);//nothing in pot
            }
            else
            {
                pBPot.setBrewingTime(3.0f);//brew with what is in pot
                pBPot.couldronAnimator.SetInteger("Brweing", 1);
            }
                
            if (pData.getRed())//test to add red potion
            {
                pBPot.getCurrentPotion().setRed(true);
            }
            if (pData.getBlue())//test to add blue potion
            {
                pBPot.getCurrentPotion().setBlue(true);
            }
            if (pData.getYellow())//test to add yellow potion
            {
                pBPot.getCurrentPotion().setYellow(true);
            }
            if (pData.getEffectID() != EFFECT_NONE)//test to add effect potion
            {
                pBPot.getCurrentPotion().setEffectID(pData.getEffectID());
            }

            //pBPot.updatePotionEffect(pBPot.potionEffectAnimator);
        }
    }

    /*public static bool canSteam(PotionData pd)//run test before adding potion to couldron
    {
        if (!pd.getRed() && !pd.getBlue() && !pd.getYellow()
                && pd.getEffectID() == EFFECT_NONE)
        {
            return false;
        }
        return true;
    }*/
}
