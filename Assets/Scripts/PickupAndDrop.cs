using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PickupAndDrop : MonoBehaviour
{
    [SerializeField] private Transform lookDir;
    [SerializeField] private Transform raycastFloor;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] float pickUpDistance = 2.0f;
    [SerializeField] private LayerMask pickUpLayerMask;

    private ObjectGrabble objectGrabble;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objectGrabble == null)
            //Not carrying an object, try to grab
            {

                //Eye Height
                if(Physics.Raycast(lookDir.position, lookDir.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
                {
                    if(raycastHit.transform.TryGetComponent(out objectGrabble))
                    {
                        objectGrabble.Grab(objectGrabPointTransform);
                    }
                }

                //Floor Height
                if (Physics.Raycast(raycastFloor.position, raycastFloor.forward, out RaycastHit raycasthit, pickUpDistance, pickUpLayerMask))
                {
                    if (raycasthit.transform.TryGetComponent(out objectGrabble))
                    {
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