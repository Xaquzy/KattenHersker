using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PickupAndDrop : MonoBehaviour
{
    [SerializeField] private Transform lookDir;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] float pickUpDistance = 2.0f;
    [SerializeField] private LayerMask pickUpLayerMask;

    private ObjectGrabble objectGrabble;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objectGrabble == null)
            {
                // Not carrying an object, try to grab
                if (Physics.Raycast(lookDir.position, lookDir.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out ObjectGrabble grabbedObject))
                    {
                        objectGrabble = grabbedObject;  // Use the class-level variable, not a new variable with the same name
                        objectGrabble.Grab(objectGrabPointTransform);
                    }
                }
            }
            else
            {
                objectGrabble.Drop();
                objectGrabble = null;
            }
        }
    }
}