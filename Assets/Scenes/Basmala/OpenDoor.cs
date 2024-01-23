using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Vector3 relativeMovement;
    [SerializeField] private float moveSpeed = 3;
    [SerializeField] private float pauseTime = 1f;

    private Vector3 targetPosition;
    private Vector3 nextPosition;
    private Vector3 initialPosition;
    private Vector3 openPosition;

    // Used for pausing at each point
    private float currentPauseTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        targetPosition = transform.position;
        nextPosition = targetPosition + relativeMovement;
        openPosition = nextPosition;
    }

    // Update is called once per frame
    // void Update()
    // {
    //     // Always be moving toward target position
    //     transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    // }

    // Update is called once per frame
    void Update()
    {
        // When we arrive at the target point...
        if (transform.position == openPosition && targetPosition == openPosition)
        {
            Debug.Log("Gate is open");
            // Start the pause timer
            currentPauseTime = pauseTime;
            // Swap to next target point
            (nextPosition, targetPosition) = (targetPosition, nextPosition);
        }

        // If we are currently paused...
        if (currentPauseTime > 0)
        {
            Debug.Log("paused");
            Debug.Log(currentPauseTime);
            Debug.Log(Time.deltaTime);
            // Let the timer tick down
            currentPauseTime -= Time.deltaTime;
        }

        // If we're supposed to move (and not currently paused)...
        if (currentPauseTime <= 0)
        {
            // Move towards target point
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    public void Activate()
    {
        // Swap target position
        (nextPosition, targetPosition) = (targetPosition, nextPosition);
        Debug.Log("Door is moving");

        // Summon camera to look while the platform slides into place
        //CinematicCamera cam = GetComponent<CinematicCamera>();
        //if (cam)
        //{
        //    cam.targetPosition = targetPosition;
        //}
    }

}