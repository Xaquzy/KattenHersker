using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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


    public GameObject Turtle;
    public GameObject Snake;
    public GameObject Horse;

    IEnumerator FinishCut()
    {
        // Check if all followers are acquired
        if (PlayerPrefs.GetInt("TurtleFollow") == 1 && PlayerPrefs.GetInt("SnakeFollow") ==1 && PlayerPrefs.GetInt("HorseFollow")==1)
        {
            Debug.Log("All followers acquired!");
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(11);
        }
    }
    void Start()
    {
        Animator animator;
        animator = GetComponent<Animator>();

        //No cursor & Move
        trueSpeed = walkSpeed;
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        StartCoroutine(FinishCut());


        Debug.Log("Turtle: " + PlayerPrefs.GetInt("TurtleFollow"));
        Debug.Log("Snake: " + PlayerPrefs.GetInt("SnakeFollow"));
        Debug.Log("Horse: " + PlayerPrefs.GetInt("HorseFollow"));

        if (PlayerPrefs.GetInt("TurtleFollow") == 1)
        {

            Debug.Log(PlayerPrefs.GetString("TurtleFollow"));
            Follower followerScript = Turtle.GetComponent<Follower>();
            Turtle.GetComponent<BoxCollider>().enabled = false;

            if (followerScript != null)
            {
                followerScript.enabled = true;
            }
            else
            {
                Debug.LogError("Follower not found on the specified GameObject.");
            }

            if (PlayerPrefs.HasKey("TurtleRecent"))
            {
                Debug.Log(PlayerPrefs.GetString("TurtleRecent"));
                transform.position = new Vector3(11.8979397f, -0.594943464f, -48.1343575f);
                PlayerPrefs.DeleteKey("TurtleRecent");
            }
            
        }
        

        if (PlayerPrefs.GetInt("SnakeFollow") == 1)
        {
            Debug.Log(PlayerPrefs.GetString("SnakeFollow"));
            Follower followerScript = Snake.GetComponent<Follower>();
            Snake.GetComponent<BoxCollider>().enabled = false;

            if (followerScript != null)
            {
                followerScript.enabled = true;
            }
            else
            {
                Debug.LogError("Follower not found on the specified GameObject.");
            }

            if (PlayerPrefs.HasKey("SnakeRecent"))
            {
                Debug.Log(PlayerPrefs.GetString("SnakeRecent"));
                transform.position = new Vector3(35.51369f, -0.59494354f, -13.06677f);
                PlayerPrefs.DeleteKey("SnakeRecent");
            }

        }
        if (PlayerPrefs.GetInt("HorseFollow") == 1)
        {
            Debug.Log(PlayerPrefs.GetString("HorseFollow"));
            Follower followerScript = Horse.GetComponent<Follower>();
            Horse.GetComponent<BoxCollider>().enabled = false;


            if (followerScript != null)
            {
                followerScript.enabled = true;
            }
            else
            {
                Debug.LogError("Follower not found on the specified GameObject.");
            }
            
            if (PlayerPrefs.HasKey("HorseRecent"))
            {
                Debug.Log(PlayerPrefs.GetString("HorseRecent"));
                transform.position = new Vector3(-12.0549f, -0.594943464f, -13.16365f);
                PlayerPrefs.DeleteKey("HorseRecent");
            }

        }

    }

        // Update is called once per frame
        void Update()
    {
        StartCoroutine(FinishCut());

        //Grounding
        isGrounded = controller.isGrounded;  

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1;
        }


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
    private void OnApplicationQuit()
    {
        Debug.Log("SLET");
        PlayerPrefs.DeleteAll();
    }
}

