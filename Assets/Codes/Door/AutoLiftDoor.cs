using UnityEngine;
public class AutoLiftDoor : MonoBehaviour
{
    public GameObject door = null; // Referensi objek pintu.
    public bool doorTriggered = false; // Status sensor.
    float doorYPos = 0f;
    float doorYBottomEnd = 0f;
    float doorYTopEnd = 0f;
    void Start()
    {
        doorYPos = door.transform.position.y;
        // Pergeseran sumbu Y (pada Kompas).
        doorYBottomEnd = doorYPos + 0.000935f; // Ujung bawah.
        doorYTopEnd = doorYPos + 4.365835f; // Ujung atas.
    }
    void OnTriggerEnter(Collider approachingCollider)
    {
        if (approachingCollider.name == "FPS Player") doorTriggered = true;
        // Jika player mendekat, maka sensor menyala.
    }
    void OnTriggerExit(Collider leavingCollider)
    {
        if (leavingCollider.name == "FPS Player") doorTriggered = false;
        // Jika player menjauh, maka sensor terhenti.
    }
    void FixedUpdate()
    {
        doorYPos = door.transform.position.y;
        // Pergeseran melalui sumbu Z objek pintu.
        if (doorTriggered && doorYPos < doorYTopEnd) // Pintu terangkat.
            door.transform.Translate(4f * Vector3.forward * Time.deltaTime);
        // Vector3.forward = (0, 0, 1).
        else if (!doorTriggered && doorYPos > doorYBottomEnd) // Pintu diturunkan.
            door.transform.Translate(-4f * Vector3.forward * Time.deltaTime);
    }
}