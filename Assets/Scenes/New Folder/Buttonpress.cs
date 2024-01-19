using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Buttonpress : MonoBehaviour
{
    public float buttonpressspeed = 0.01f;
    private bool ready = true;

    [Tooltip("Action to take when button is pressed")]
    public UnityEvent OnPress;

    private Vector3 nextPosition;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {      
        targetPosition = transform.localPosition;

        // When pressed, the button should move 0.04m downwards
        nextPosition = targetPosition;
        nextPosition.y -= 0.04f;
    }

    

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition,
                                                      targetPosition,
                                                      buttonpressspeed * Time.deltaTime);
    }

public void OnHit()
{
    // Only allow the button to be pressed if it is not already pressed down
    if (ready)
    {
        // Immediately disallow further button presses
        ready = false;

        // Swap target- and next position
        (nextPosition, targetPosition) = (targetPosition, nextPosition);

        // Run whatever action has been configured in the editor
        OnPress.Invoke();

        Debug.Log("Button is pressed!");

    }
}
    public void Release()
    {
        (nextPosition, targetPosition) = (targetPosition, nextPosition);
        ready = true;
    }
}
