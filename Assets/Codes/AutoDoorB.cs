using UnityEngine;
public class AutoDoorB : MonoBehaviour
{
    public GameObject door; // Referensi objek pintu.
    public bool doorTriggered = false; // Status sensor.
    float doorZPos; // Menggeser pintu secara horizontal (sumbu Z).
    void FixedUpdate()
    {
        doorZPos = door.transform.position.z;
        // Pergeseran melalui sumbu X objek pintu.
        if (doorTriggered && doorZPos > -34.9f)
            door.transform.Translate(-1.5f * Vector3.right * Time.deltaTime);
        // Vector3.right = (1, 0, 0).
        else if (!doorTriggered && doorZPos < -32.65f)
            door.transform.Translate(1.5f * Vector3.right * Time.deltaTime);
        // Sumbu X pintu: -34.9f s/d -32.6f.
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