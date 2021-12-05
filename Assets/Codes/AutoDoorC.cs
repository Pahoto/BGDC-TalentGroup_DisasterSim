using UnityEngine;
public class AutoDoorC : MonoBehaviour
{
    public GameObject door; // Referensi objek pintu.
    public bool doorTriggered = false; // Status sensor.
    float doorYPos; // Menggeser pintu secara vertikal (sumbu Y).
    void FixedUpdate()
    {
        doorYPos = door.transform.position.y;
        // Pergeseran melalui sumbu Z objek pintu.
        if (doorTriggered && doorYPos < 8.2469f)
            door.transform.Translate(4f * Vector3.forward * Time.deltaTime);
        // Vector3.forward = (0, 0, 1).
        else if (!doorTriggered && doorYPos > 3.882f)
            door.transform.Translate(-4f * Vector3.forward * Time.deltaTime);
        // Sumbu Z pintu: 3.8f - 8.2f.
    }
    void OnTriggerEnter(Collider approachingCollider)
    {
        if (approachingCollider.name == "FPS Player")
            doorTriggered = true;
        // Jika player mendekat, maka sensor menyala.
    }
    void OnTriggerExit(Collider leavingCollider)
    {
        if (leavingCollider.name == "FPS Player")
            doorTriggered = false;
        // Jika player menjauh, maka sensor terhenti.
    }
}