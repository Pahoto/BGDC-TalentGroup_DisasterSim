using UnityEngine;
public class AutoSlideDoor : MonoBehaviour
{
    public GameObject door = null; // Referensi objek pintu.
    public bool doorTriggered = false; // Status sensor.
    float doorZPos = 0f, doorZLeftEnd = 0f, doorZRightEnd = 0f;
    void Start()
    {
        doorZPos = door.transform.position.z;
        // Pergeseran sumbu Z (pada Kompas).
        doorZLeftEnd = doorZPos - 0.02276f; // Ujung kiri.
        doorZRightEnd = doorZPos - 2.27276f; // Ujung kanan.
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
        doorZPos = door.transform.position.z;
        // Pergeseran melalui sumbu X objek pintu.
        if (doorTriggered && doorZPos > doorZRightEnd) // Pintu terbuka.
            door.transform.Translate(-1.5f * Vector3.right * Time.deltaTime);
        // Vector3.right = (1, 0, 0).
        else if (!doorTriggered && doorZPos < doorZLeftEnd) // Pintu tertutup.
            door.transform.Translate(1.5f * Vector3.right * Time.deltaTime);
    }
}