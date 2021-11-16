using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    float x = 0, z = 0;
    Vector3 xZDirection;
    CharacterController controller;
    public float xZSpeed = 12f, gravity = -10f,
        groundDistance = 0.045f, jumpHeight = 1.6f;
    public Vector3 yDirection;
    public bool isGrounded;
    public Transform groundChecker;
    public LayerMask groundMask;
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }
    void Update()
    {
        if (isGrounded && yDirection.y < 0) yDirection.y = 0;
        
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        xZDirection = transform.right * x + transform.forward * z;
        controller.Move(xZDirection * xZSpeed * Time.deltaTime);
        
        if(isGrounded && Input.GetKeyDown("space"))
            yDirection.y = Mathf.Sqrt(-2 * gravity * jumpHeight);

        yDirection.y += gravity * Time.deltaTime;
        controller.Move(yDirection * Time.deltaTime);
    }
    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundChecker.
            position, groundDistance, groundMask);
    }
}