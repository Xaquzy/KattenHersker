using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PickupAndDrop : MonoBehaviour
{
    [SerializeField] private Transform lookDir;
    [SerializeField] private Transform ObjectGrabPointTransform;
    [SerializeField] float pickUpDistance = 2.0f;
    [SerializeField] private LayerMask pickUpLayerMask;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(lookDir.position, lookDir.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
            {
                if (raycastHit.transform.TryGetComponent(out ObjectGrabble objectGrabble))
                {
                    UnityEngine.Debug.Log(objectGrabble);
                }
            }
        }
    }
}
