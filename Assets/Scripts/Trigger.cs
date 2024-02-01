using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.name);
        if (other.CompareTag("TheKey"))
        {
            Debug.Log("Something opened... YAAAYY FINALLY");
            // kald på den funktion der åbner døren
        }
        else
        {
            Debug.Log("Something DID NOT opened... you cant code idiot");
        }
    }

}
