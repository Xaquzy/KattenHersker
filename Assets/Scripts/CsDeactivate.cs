using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsDeactivate : MonoBehaviour
{
    // Start is called before the first frame update
    public static CsDeactivate Instance;
    [SerializeField] private GameObject player;
    [SerializeField] private Movement movement;
    [SerializeField] private CinemachineFreeLook freelookcam;
    private void Awake()
    {
        Instance = this;
    }

    public void Activate()
    {
        player.SetActive(true);
        movement.enabled = true;
        freelookcam.enabled = true;
    }

    public void Deactivate()
    {
        player.SetActive(false);
        movement.enabled = false;
        freelookcam.enabled = false;
    }
}
