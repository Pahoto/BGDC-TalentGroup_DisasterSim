using UnityEngine;
public class AutoSlideDoor : MonoBehaviour
{
    public GameObject door = null; // Referensi objek pintu.
    public bool doorTriggered = false; // Status sensor.
    float doorZPos = 0f;
    float doorZLeftEnd = 0f; // -33...
    float doorZRightEnd = 0f; // -34...
    public AudioSource openSound = null;
    public AudioSource closeSound = null;
    void Start()
    {
        doorZPos = door.transform.position.z;
        // Pergeseran sumbu Z (pada Kompas).
        doorZLeftEnd = doorZPos - 0.02276f; // Ujung kiri.
        doorZRightEnd = doorZPos - 2.27276f; // Ujung kanan.
        // Pakai AudioMixer, atur Master hingga maks (20).
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
        {
            openSound.time = doorZLeftEnd - doorZPos;
            openSound.Play();
            closeSound.Stop();
            door.transform.Translate(-Vector3.right * Time.deltaTime);
        }
        // Vector3.right = (1, 0, 0).
        else if (!doorTriggered && doorZPos < doorZLeftEnd) // Pintu tertutup.
        {
            closeSound.time = doorZPos - doorZRightEnd;
            closeSound.Play();
            openSound.Stop();
            door.transform.Translate(Vector3.right * Time.deltaTime);
        }
        else
        { // Posisi pintu sudah di ujung.
            openSound.Stop();
            closeSound.Stop();
        }
    }
}