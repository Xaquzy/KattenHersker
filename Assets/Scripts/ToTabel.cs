using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTabel : MonoBehaviour
{
    private GameObject NumberObject;
    private int counter = 0;
    [SerializeField] private int NewSceneNumber = 1;
    [SerializeField] private int antalTalManSkalFinde;

        void Update()
    {
      
        if (counter == antalTalManSkalFinde)
        {
            Debug.Log("You have now collected all numbers");
            PlayerPrefs.SetInt("TurtleFollow", 1);
            PlayerPrefs.SetString("TurtleRecent", "The turtle was most recently aquired");
            SceneManager.LoadScene(NewSceneNumber);
        }

    }


    private void CheckNumber(GameObject NumberObject)
    {
        AssignNumber NumberHolder = NumberObject.GetComponent<AssignNumber>();
        if(NumberHolder != null)
        {
            float number = NumberHolder.number;

            if (number % 2 == 0)
            {
                Debug.Log("This number is divisible by 2!");
                counter = counter + 1;
                Destroy(NumberObject);
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

    

    private void OnTriggerEnter(Collider Input)
    {
        if (Input.CompareTag("Number"))
        {
            Debug.Log("The number is in the machine");
            CheckNumber(Input.gameObject);
        }
        else
        {
            Debug.LogWarning("Object with tag 'Number' not found");
        }
    }

}
