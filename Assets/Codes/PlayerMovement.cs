using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    float x = 0f, z = 0f;
    Vector3 xZDirection = new Vector3(0f, 0f, 0f);
    CharacterController controller = null;
    public float xZSpeed = 4f, gravity = -10f, groundDistance = 0.06f, jumpHeight = 1.6f, roofDistance = 0.1f;
    public Vector3 yDirection = new Vector3(0f, 0f, 0f);
    public bool isGrounded, isRoofed;
    public Transform groundChecker = null, roofChecker = null;
    public LayerMask groundMask, roofMask;

    // For Pressure Plate
    private GameObject[] pressurePlates;
    GameObject obstacle;

    public bool pressed = false;
    private bool allPressed = false;

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();

        // For Pressure Plate
        pressurePlates = GameObject.FindGameObjectsWithTag("Pressure Plate");

        obstacle = GameObject.Find("LALALA");
    }
    void Update()
    {
        if (isGrounded && yDirection.y < 0f) yDirection.y = 0f;
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        xZDirection = transform.right * x + transform.forward * z;
        controller.Move(xZDirection * xZSpeed * Time.deltaTime);
        if(isGrounded && Input.GetKeyDown(KeyCode.Space)) yDirection.y = Mathf.Sqrt(-2f * gravity * jumpHeight);
        yDirection.y += gravity * Time.deltaTime;
        controller.Move(yDirection * Time.deltaTime);
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