using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class Tip : MonoBehaviour
{
    public Text tipText;
    public float raycastDistance = 5f;

    void Update()
    {
        // Cast a ray from the camera's forward direction
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        // Check if the ray hits something
        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            // Check if the hit object has a TipComponent (you can customize this)
            Message tipComponent = hit.collider.GetComponent<Message>();
            if (tipComponent != null)
            {
                // Display the tip
                tipText.text = tipComponent.GetTip();
                tipText.gameObject.SetActive(true);
            }
            else
            {
                // Hide the tip if not looking at a relevant object
                tipText.gameObject.SetActive(false);
            }
        }
        else
        {
            // Hide the tip if not hitting anything
            tipText.gameObject.SetActive(false);
        }
    }
}
