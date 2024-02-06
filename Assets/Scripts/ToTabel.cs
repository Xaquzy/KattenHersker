using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ToTabel : MonoBehaviour
{
    private GameObject TheNumber;


    // Start is called before the first frame update
    void Start()
    {
        TheNumber = GameObject.FindWithTag("Number");
        Debug.Log("Number found");

        if (TheNumber == null)
        {
            Debug.LogError("GameObject with tag 'Number' not found.");
        }

    }

    // Update is called once per frame
    void Update()
    {


    }


    private void CheckNumber()
    {
        AssignNumber NumberHolder = TheNumber.GetComponent<AssignNumber>();
        if(NumberHolder != null)
        {
            float number = NumberHolder.number;

            if (number % 2 == 0)
            {
                Debug.Log("This number is divisible by 2!");
            }
            
            else
            {
                Debug.Log("This number is not divisible by 2! Try again.");
            }

        }
        else
        {
            Debug.LogError("NumberHolder component not found on the GameObject with the tag.");
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Number"))
        {
            Debug.Log("The number is in the machine");
            CheckNumber();
        }
        else
        {
            Debug.LogWarning("Object with tag 'Number' not found");
        }
    }


}
