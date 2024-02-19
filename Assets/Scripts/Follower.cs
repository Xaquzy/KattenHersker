using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Follower : MonoBehaviour
{
    public Transform targetPlayer;      // The player to follow
    public float moveSpeed = 5f;        // The speed at which the following player moves
    public float stoppingDistance = 2f; // The distance at which the follower stops
    private float rotationSpeed = 5f;   // The speed at which the following player rotates towards the target
    private CharacterController characterController;
    public Animator animator;



    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {

        Following();
    }

    public void Following()
    {
        // Calculate the direction from the current player to the target player
        Vector3 direction = targetPlayer.position - transform.position;
        direction.y = 0f; 
        
        // Rotate the player towards the target player
        Quaternion toRotation = Quaternion.LookRotation(-direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

        if (direction.magnitude > stoppingDistance)
        {
  
            // Move the player towards the target player
            characterController.Move(direction.normalized * moveSpeed * Time.deltaTime);
        }

        //Animation
        if (direction.magnitude <= 0)
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);
        }
    }

}
  
