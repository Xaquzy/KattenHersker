using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformChangeButton : MonoBehaviour
{
    // The new position to set when the player stands on the button.
    public Vector3 newPosition = new Vector3(0f, 0f, 3f);

    void OnCollisionEnter(Collision collision)
    {
        // Check if the entering object has the "Player" tag.
        if (collision.collider.CompareTag("Player"))
        {
            // Change the player's transform position to the new position.
            collision.transform.position = newPosition;
            Debug.Log("Player's position changed!");
        }
    }
}
