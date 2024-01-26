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

        }
    }
}