using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedPotion : MonoBehaviour
{
    Vector3 startPos;
    GameObject custom;
    bool customer;

    private void Start()
    {
        startPos = transform.position;
        //Debug.Log(startPos);
    }
    public void checkLocation()
    {
        if (customer)
        {
            custom.GetComponent<Customer>().givePotion(this.GetComponent<SetupPotionDrag>().getPotionData());
            this.GetComponent<SetupPotionDrag>().clear();
            transform.position = startPos;

            Debug.Log("given to customer");
        }
        else
        {
            transform.position = startPos;

            Debug.Log("droped");
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("WHY");
        if (other.transform.tag == "Customer")
        {
            Debug.Log("Hit to customer");
            customer = true;
            custom = other.transform.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Passed Customer");
        customer = false;
        custom = null;
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("WHY Stay");
        if (other.transform.tag == "Customer")
        {
            Debug.Log("Stayed On customer");
            customer = true;
            custom = other.transform.gameObject;
        }
    }
}
