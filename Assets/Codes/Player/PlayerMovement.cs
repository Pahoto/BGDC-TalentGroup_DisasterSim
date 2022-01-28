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

    void Start()
    {
        controller = GetComponentInParent<CharacterController>();

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
        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) yDirection.y = Mathf.Sqrt(-2f * gravity * jumpHeight);
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