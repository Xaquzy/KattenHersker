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
        if(other.CompareTag("Key"))
        {
            Debug.Log("Something opened");
            // kald p� den funktion der �bner d�ren
        }
        else
        {
            Debug.Log("Object with tag 'Key' not found");
        }
    }

}
