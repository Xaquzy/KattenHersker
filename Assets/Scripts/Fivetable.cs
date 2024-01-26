using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fivetable : MonoBehaviour
{
    private GameObject TheNumber;


    // Start is called before the first frame update
    void Start()
    {
        TheNumber = GameObject.FindWithTag("Number");

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

            if (number % 5 == 0)
            {
                Debug.Log("This number is divisible by 5!");
            }

            else
            {
                Debug.Log("This number is not divisible by 5! Try again.");
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
