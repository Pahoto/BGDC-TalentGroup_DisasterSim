using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    float x = 0f;
    float z = 0f;
    Vector3 xZDirection = new Vector3(0f, 0f, 0f);
    CharacterController controller = null;
    public float xZSpeed = 4f;
    public float gravity = -10f;
    public float groundDistance = 0.06f;
    public float jumpHeight = 1.6f;
    public float roofDistance = 0.1f;
    public Vector3 yDirection = new Vector3(0f, 0f, 0f);

    public bool isGrounded = false;
    public bool isRoofed = false;
    public Transform groundChecker = null;
    public Transform roofChecker = null;
    public LayerMask groundMask;
    public LayerMask roofMask;

    // For Pressure Plate
    GameObject[] pressurePlates;
    GameObject obstacle = null;

    public bool pressed = false;
    bool allPressed = false;

    public AudioSource walkSound = null;
    public AudioSource jumpSound = null;
    public AudioSource landSound = null;
    public AudioSource bedSound = null;
    public BedTrigger bedTrigger = null;
    public bool isWalking = false;
    public bool isPressed = false;
    bool isJump = false;

    void Start()
    {
        controller = GetComponentInParent<CharacterController>();

        // For Pressure Plate
        pressurePlates = GameObject.FindGameObjectsWithTag("Pressure Plate");

        obstacle = GameObject.Find("LALALA");

        walkSound = this.GetComponent<AudioSource>();
        bedTrigger = FindObjectOfType<BedTrigger>();
    }
    void CheckWalkButtonPressed()
    {
        if (
            (x >= -1f && x < 0f) ||
            (x > 0f && x <= 1f) ||
            (z >= -1f && z < 0f) ||
            (z > 0f && z <= 1f)
        ) isPressed = true;
        else isPressed = false;
    }
    void SetWalk()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        xZDirection = transform.right * x + transform.forward * z;
        controller.Move(xZDirection * xZSpeed * Time.deltaTime);
    }
    void Walk()
    {
        SetWalk();
        CheckWalkButtonPressed();
        if (!isWalking && isPressed)
        {
            if (bedTrigger.onBed)
            {
                bedSound.Play();
                walkSound.Stop();
            }
            else
            {
                walkSound.Play();
                bedSound.Stop();
            }
            isWalking = true;
        }
        else if (!isPressed)
        {
            bedSound.Stop();
            walkSound.Stop();
            isWalking = false;
        }
    }
    void SetJump()
    {
        yDirection.y += gravity * Time.deltaTime;
        controller.Move(yDirection * Time.deltaTime);
    }
    void Jump()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isJump && !isRoofed)
            {
                yDirection.y = Mathf.Sqrt(-2f * gravity * jumpHeight);
                jumpSound.Play();
                bedSound.Stop();
                walkSound.Stop();
                isJump = true;
            }
            else if (yDirection.y <= 0f && isJump)
            {
                yDirection.y = 0f;
                landSound.Play();
                walkSound.Play();
                isJump = false;
            }
        }
        SetJump();
    }
    void Update()
    {
        Walk();
        Jump();
    }
    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, groundDistance, groundMask);
        isRoofed = Physics.CheckSphere(roofChecker.position, roofDistance, roofMask);
        if (isRoofed) yDirection.y += 3f * gravity * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pressure Plate")
        {
            if (pressed == false)
            {
                collision.gameObject.GetComponent<Renderer>().material.color = Color.cyan;

                pressed = true;
                allPressed = true;

                foreach (GameObject pressurePlate in pressurePlates)
                {
                    if (pressurePlate.GetComponent<PressurePlate>().pressed == false)
                    {
                        allPressed = false;
                    }
                }

                if (allPressed == true)
                {
                    obstacle.SetActive(false);
                }
            }
        }
    }
}