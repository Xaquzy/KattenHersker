using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerMove : MonoBehaviour
{
    // Movement
    public Transform Player;
    public float speed = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Follow
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed);


        //Animation
        //if (speed > 0)
        //{
        // animator.SetBool("NAVN", true);
        //}

        //else
        //{
        // animator.SetBool("NAVN", false);
        //}


    }
}