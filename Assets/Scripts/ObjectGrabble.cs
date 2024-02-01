using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectGrabble : MonoBehaviour
{
    private Rigidbody objectRigidBody;
    private Transform objectGrabPointTransform;
    private void Awake()
    {
        objectRigidBody = GetComponent<Rigidbody>();
    }
    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRigidBody.useGravity = false;
        objectRigidBody.freezeRotation = true;
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        objectRigidBody.useGravity = true;
        objectRigidBody.freezeRotation = true;
    }
 
    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null) 
        {
            float lerpSpeed = 10f;
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRigidBody.MovePosition(newPosition);
        }
    }
}
