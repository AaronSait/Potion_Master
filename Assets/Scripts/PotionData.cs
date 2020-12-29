//Written By Christopher Deane
public class PotionData
{
    public PotionData() { }
    public void clear()
    {
        containsBlue = false;
        containsRed = false;
        containsYellow = false;
        effectID = 0;
    }

    public bool containsRed = false; public bool getRed() { return containsRed; } public void setRed(bool r) { containsRed = r; }
    private bool containsBlue = false; public bool getBlue() { return containsBlue; } public void setBlue(bool b) { containsBlue = b; }
    private bool containsYellow = false; public bool getYellow() { return containsYellow; } public void setYellow(bool y) { containsYellow = y; }

    private int effectID = 0; public int getEffectID() { return effectID; } public void setEffectID(int e) { effectID = e; }
}
