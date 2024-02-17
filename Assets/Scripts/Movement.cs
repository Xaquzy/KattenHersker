using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
//1
public class Movement : MonoBehaviour
{
    //Essentials
    public Transform mainCam;
    CharacterController controller;
    float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    

    //Animation
    public Animator PlayerAnimator;

    //Movement
    Vector2 movement;
    public float walkSpeed = 4;
    public float sprintSpeed = 6;
    float trueSpeed;

    //Jumping
    public float jumpHeight = 1;
    public float gravity = (int)9.82;
    bool isGrounded;
    Vector3 velocity;
    private int counter = 2;


    //bool TurtleIsFollowing = false;
    //bool SnakeIsFollowing = false;
    //bool HorseIsFollowing = false;

    public GameObject Turtle;
    public GameObject Snake;
    public GameObject Horse;



    void Start()
    {
        Animator animator;
        animator = GetComponent<Animator>();

        //No cursor & Move
        trueSpeed = walkSpeed;
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;


        if (PlayerPrefs.HasKey("TurtleFollow"))
        {

            Debug.Log(PlayerPrefs.GetString("TurtleFollow"));
            transform.position = new Vector3(11.8979397f, -0.594943464f, -48.1343575f);
            Follower followerScript = Turtle.GetComponent<Follower>();
            PlayerPrefs.DeleteKey("TurtleFollow");

            if (followerScript != null)
            {
                followerScript.enabled = true;
            }
            else
            {
                Debug.LogError("Follower not found on the specified GameObject.");
            }

        }
        else
        {
            Debug.Log("No PlayerPref with the key 'TurtleFollow' was found.");
        }

        if (PlayerPrefs.HasKey("SnakeFollow"))
        {
            Debug.Log(PlayerPrefs.GetString("SnakeFollow"));
            transform.position = new Vector3(35.51369f, -0.59494354f, -13.06677f);
            Follower followerScript = Snake.GetComponent<Follower>();
            PlayerPrefs.DeleteKey("SnakeFollow");

            if (followerScript != null)
            {
                followerScript.enabled = true;
            }
            else
            {
                Debug.LogError("Follower not found on the specified GameObject.");
            }

        }
        if (PlayerPrefs.HasKey("HorseFollow"))
        {
            Debug.Log(PlayerPrefs.GetString("HorseFollow"));
            transform.position = new Vector3(11.8979397f, -0.594943464f, -48.1343575f);
            Follower followerScript = Horse.GetComponent<Follower>();
            PlayerPrefs.DeleteKey("HorseFollow");

            if (followerScript != null)
            {
                followerScript.enabled = true;
            }
            else
            {
                Debug.LogError("Follower not found on the specified GameObject.");
            }

        }

    }

        // Update is called once per frame
        void Update()
    {
        //Grounding
        isGrounded = controller.isGrounded;  

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1;
        }

        ////Sprinting
        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    trueSpeed = sprintSpeed;
        //}
        //if (Input.GetKeyUp(KeyCode.LeftShift))
        //{
        //    trueSpeed = walkSpeed;
        //}


        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 direction = new Vector3(movement.x, 0, movement.y).normalized;

        //Set rotation equal to the look direction
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        if (direction.magnitude >= 0.1f)
        {
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * trueSpeed * Time.deltaTime);
        }

        //Jumping (max doublejump)
        if (isGrounded)
        {
            counter = 2;
        }

        if (Input.GetKeyDown(KeyCode.Space) && counter > 0)
        {
            velocity.y = Mathf.Sqrt((jumpHeight * 10) * -2f * gravity);
            counter = counter - 1;
        }


        if (velocity.y > -20)
        {
            velocity.y += (gravity * 30) * Time.deltaTime;
        }
        controller.Move(velocity * Time.deltaTime);

        //Animation
        if (direction.magnitude <= 0)
        {
            PlayerAnimator.SetBool("Moving", false);
        }
        else
        {
            PlayerAnimator.SetBool("Moving", true);
        }

    }
}

