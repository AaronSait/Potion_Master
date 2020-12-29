using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public Customer[] allCustomers;

    private int numberOfActiveCustomers = 1;
    private GameManager gameManager;

    private const int R = 0;
    private const int Y = 1;
    private const int B = 2;
    private bool[] RYB;
    private int numberOfReqColours = 0;

    // Start is called before the first frame update
    void Start()
    {
        RYB = new bool[3];
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numberOfActiveCustomers; i++)
        {
            if (allCustomers[i].readyForRequirement)
            {
                calculateColour();
                allCustomers[i].setRequest(RYB[R], RYB[Y], RYB[B], calculateEffect(), calculateQuantity());
            }
        }

        if (gameManager.getNoHappyCust() > 0)
        {
            if (numberOfActiveCustomers < allCustomers.Length)
                numberOfActiveCustomers++;
        }
        /*else if (gameManager.getNoHappyCust() > 3)
        {
            if (numberOfActiveCustomers < allCustomers.Length)
                numberOfActiveCustomers++;
        }*/
    }

    private void calculateColour()
    {
        if (gameManager.getNoHappyCust() > 7 && Random.Range(0, 10) == 1)
        {
            for (int i = 0; i < RYB.Length; i++)
            {
                RYB[i] = true;
            }
            numberOfReqColours = 3;
        }
        else if (Random.Range(0, 10) > 3 || gameManager.getNoHappyCust() < 1)//with one colour
        {
            for (int i = 0; i < RYB.Length; i++)
            {
                RYB[i] = false;
            }

            RYB[Random.Range(0, 3)] = true;
            numberOfReqColours = 1;
        }
        else//with two colours
        {
            for (int i = 0; i < RYB.Length; i++)
            {
                RYB[i] = true;
            }

            RYB[Random.Range(0, 3)] = false;
            numberOfReqColours = 2;
        }
    }

    private int calculateEffect()
    {
        if (numberOfReqColours == 1)//give an effect
        {
            return Random.Range(1, 4);
        }
        else if (numberOfReqColours == 2 && gameManager.getNoHappyCust() > 4 && Random.Range(0, 5) > 2)
        {
            return Random.Range(1, 4);
        }
        else if (numberOfReqColours == 3 && gameManager.getNoHappyCust() > 8 && Random.Range(0, 5) > 2)
        {
            return Random.Range(1, 4);
        }
        return 0;
    }

    private int calculateQuantity()
    {
        if (gameManager.getNoHappyCust() < 5)
        {
            return 1;
        }
        else if (Random.Range(0, 100) == 1)
        {
            return 20;
        }
        return Random.Range(1, 4);
    }
}
