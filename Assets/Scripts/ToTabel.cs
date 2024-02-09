using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTabel : MonoBehaviour
{
    private GameObject TheNumber;
    [SerializeField] private float counter = 0;
    [SerializeField] private int NewSceneNumber = 1;


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
        if (counter == 5)
        {
            PlayerPrefs.SetString("TurtleFollow","Du er kommet ud af labyrinten! Skildpadden følger dig nu!");
            SceneManager.LoadScene(NewSceneNumber);
        }


    }


    private void CheckNumber(GameObject numberObject)
    {
        AssignNumber NumberHolder = TheNumber.GetComponent<AssignNumber>();
        if(NumberHolder != null)
        {
            float number = NumberHolder.number;

            if (number % 2 == 0)
            {
                Debug.Log("This number is divisible by 2!");
                counter = counter + 1;
                Destroy(numberObject);
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
            TheNumber = other.gameObject;
            CheckNumber(other.gameObject);
        }
        else
        {
            Debug.LogWarning("Object with tag 'Number' not found");
        }
    }


}
