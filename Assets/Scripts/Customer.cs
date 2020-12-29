using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    private SpriteRenderer characterImg;
    public Image requiredPotionImg_Col;
    public Image requiredPotionImg_Efct;
    public Text requiredQuantityTxt;
    public GameObject requirementBackground;

    public GameObject hlPoint;
    public GameObject ncsPoint;
    public GameObject sPoint;
    private Vector3 happyLeavePoint;
    private Vector3 newCustomerStartPoint;
    private Vector3 stationaryPoint;

    public bool readyForRequirement = true;

    private float reactTimer = 0f;//for reaction
    private float happyLeaveTimer = 0f;//for happy leaving screen
    private float sadLeaveTimer = 0f;//for sad leaving screen
    private float enterTimer = 0f;//for entering screen
    private float maxMoveTimer = 2f;

    private float randomWaitTimer = 0f;

    private AssetsManager assetManager;
    private GameManager gameManager;

    private PotionData requiredPotion; public PotionData getRequiredPotionData() { return requiredPotion; }
    private int requiredQuantity; public int getRequiredQuantity() { return requiredQuantity; }

    void Start()
    {
        characterImg = gameObject.GetComponent<SpriteRenderer>();
        happyLeavePoint = hlPoint.transform.localPosition;
        newCustomerStartPoint = ncsPoint.transform.localPosition;
        stationaryPoint = sPoint.transform.localPosition;
        requiredPotion = new PotionData();
        requiredQuantity = 0;
        requirementBackground.SetActive(false);
        assetManager = GameObject.Find("AssetManager").GetComponent<AssetsManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        gameObject.transform.localPosition = newCustomerStartPoint;
    }

    void Update()
    {
        if (randomWaitTimer > 0f)
        {
            randomWaitTimer -= Time.deltaTime;
            if (randomWaitTimer <= 0f)
                randomWaitTimer = 0f;
        }
        else if (reactTimer > 0f)
        {
            reactTimer -= Time.deltaTime;
        } 
        else if (enterTimer > 0f)
        {
            enterTimer -= Time.deltaTime;
            if (enterTimer <= 0f)//if the customer has finished entering?
            {
                //make their demands visible
                enterTimer = 0f;
                requirementBackground.SetActive(true);
            }
            Vector3 v = stationaryPoint + ((newCustomerStartPoint - stationaryPoint) * ((1f / maxMoveTimer) * enterTimer));
            characterImg.transform.position = new Vector3(v.x, v.y, v.z);
        }
        else if (happyLeaveTimer > 0f)
        {
            happyLeaveTimer -= Time.deltaTime;
            if (happyLeaveTimer <= 0f)//if the customer has finished leaving?
            {
                happyLeaveTimer = 0f;
                readyForRequirement = true;
            }
            Vector3 v = happyLeavePoint + ((stationaryPoint - happyLeavePoint) * ((1f / maxMoveTimer) * happyLeaveTimer));
            characterImg.transform.position = new Vector3(v.x, v.y, v.z);
        }
        else if (sadLeaveTimer > 0f)
        {
            sadLeaveTimer -= Time.deltaTime;
            if (sadLeaveTimer <= 0f)//if the customer has finished leaving?
            {
                sadLeaveTimer = 0f;
                readyForRequirement = true;
            }
            Vector3 v = newCustomerStartPoint + ((stationaryPoint - newCustomerStartPoint) * ((1f / maxMoveTimer) * sadLeaveTimer));
            characterImg.transform.position = new Vector3(v.x, v.y, v.z);
        }
    }

    public void setRequest(bool R, bool Y, bool B, int effect, int quantity)//setup character with new request
    {
        readyForRequirement = false;
        requiredPotion.setRed(R);
        requiredPotion.setBlue(B);
        requiredPotion.setYellow(Y);
        requiredPotion.setEffectID(effect);
        requiredQuantity = quantity;

        requiredQuantityTxt.text = "x" + requiredQuantity;
        characterImg.sprite = assetManager.normalCustmer;
        requiredPotionImg_Col.sprite = assetManager.findColourSprite(R, B, Y);
        requiredPotionImg_Efct.sprite = assetManager.findEffectSprite(effect);
        requiredPotionImg_Efct.color = assetManager.colourPotionEffects(R, B, Y);
        enterTimer = maxMoveTimer;//start moving sprite in
        if (gameManager.getNoHappyCust() > 1)
        {
            randomWaitTimer = Random.Range(0, 3);
        }
    }

    public void givePotion(PotionData enteredPotion)//used to test if potion is correct for character
    {
        Debug.Log("Red - Req: " + requiredPotion.getRed() + " Got: " + enteredPotion.getRed());
        Debug.Log("Blue - Req: " + requiredPotion.getBlue() + " Got: " + enteredPotion.getBlue());
        Debug.Log("Yellow - Req: " + requiredPotion.getYellow() + " Got: " + enteredPotion.getYellow());
        Debug.Log("Efct - Req: " + requiredPotion.getEffectID() + " Got: " + enteredPotion.getEffectID());

        if (enteredPotion.getRed() || enteredPotion.getBlue() || enteredPotion.getYellow() || enteredPotion.getEffectID() != 0)
        {
            if (requiredPotion.getRed() == enteredPotion.getRed() && requiredPotion.getBlue() == enteredPotion.getBlue()
                && requiredPotion.getYellow() == enteredPotion.getYellow() && requiredPotion.getEffectID() == enteredPotion.getEffectID())
            {
                requiredQuantity--;
                requiredQuantityTxt.text = "x" + requiredQuantity;

                int bonus = 0;
                if (enteredPotion.getRed()) bonus += 10;
                if (enteredPotion.getBlue()) bonus += 10;
                if (enteredPotion.getYellow()) bonus += 10;
                if (enteredPotion.getEffectID() != 0) bonus += 10;

                gameManager.addToPoints(30 + bonus);
                if (requiredQuantity <= 0)
                {
                    characterImg.sprite = assetManager.happyCustomer;
                    reactTimer = maxMoveTimer;
                    happyLeaveTimer = maxMoveTimer;
                    gameManager.addToHappyCust(1);
                    requirementBackground.SetActive(false);
                }
            }
            else
            {
                characterImg.sprite = assetManager.sadCustomer;
                reactTimer = maxMoveTimer;
                sadLeaveTimer = maxMoveTimer;
                gameManager.addToPoints(-20);
                gameManager.addToSadCust(1);
                requirementBackground.SetActive(false);
            }
        }
        enteredPotion.clear();//should clear original cauldron potion too
    }
}
