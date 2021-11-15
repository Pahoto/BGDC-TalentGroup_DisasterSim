using UnityEngine; // Namespace Utama.
public class MouseLook : MonoBehaviour
{
    // FPS Player (controller) mewariskan body dan mainCamera.
    float mouseX = 0, mouseY = 0;
    // Pertambahan sudut setiap pergeseran Mouse.
    public float mouseXSensi = 120f, mouseYSensi = 240f, xRotation = 0;
    // mouSensi: Sensitivitas pergeseran Mouse.
    // xRotation:  Besar sudut rotasi vertikal.
    public Transform controller; // Komponen FPS Player.
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // Tampilan kursor dimatikan selama bermain.
    }
    void Update()
    {
        // Pergerakan Mouse Horizontal:
        mouseX = Input.GetAxis("Mouse X") * mouseXSensi * Time.deltaTime;
        // Merotasi FPS Player terhadap sumbu y:
        controller.Rotate(Vector3.up * mouseX);
        // Pergerakan Mouse Vertikal:
        mouseY = Input.GetAxis("Mouse Y") * mouseYSensi * Time.deltaTime;
        // Mengapit agar rotasi vertikal tidak melebihi 90 derajat.
        xRotation = Mathf.Clamp(xRotation - mouseY, -90f, 90f);
        // Merotasi mainCamera terhadap sumbu x:
        transform.localRotation = Quaternion.Euler(Vector3.right * xRotation);
    }
}