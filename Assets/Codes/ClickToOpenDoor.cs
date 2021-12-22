using System.Collections; // Untuk Coroutine.
using UnityEngine;
public class ClickToOpenDoor : MonoBehaviour
{
    public Animator doorAnim = null, sensorAnim = null; // Membuka-tutup pintu dengan animasi.
    public bool doorTriggered = false, openingDoor = false, pauseInteraction = false;
    void OnTriggerEnter(Collider approachingCollider)
    {
        if (approachingCollider.name == "Crosshair") doorTriggered = true;
        // Jika player mendekat, maka sensor menyala.
    }
    void OnTriggerExit(Collider leavingCollider)
    {
        if (leavingCollider.name == "Crosshair") doorTriggered = false;
        // Jika player menjauh, maka sensor terhenti.
    }
    IEnumerator PauseInteraction()
    {
        pauseInteraction = true; // Dijalankan dengan return.
        yield return new WaitForSeconds(1f); // 60 keyframes.
        pauseInteraction = false; // Dijalankan setelah return.
    }
    void Update()
    { // Player harus berada di sekitar Sensor.
        if (doorTriggered && Input.GetKeyDown(KeyCode.E) && !pauseInteraction)
        { // Setiap klik tombol E di keyboard.
            if (!openingDoor)
            {
                doorAnim.Play("Door Open", 0, 0f);
                sensorAnim.Play("Door Open", 0, 0f);
                openingDoor = true; // Pintu terbuka.
                StartCoroutine(PauseInteraction());
            } // Start Coroutine = memulai jeda.
            else
            {
                doorAnim.Play("Door Close", 0, 0f);
                sensorAnim.Play("Door Close", 0, 0f);
                openingDoor = false; // Pintu tertutup.
                StartCoroutine(PauseInteraction());
            } // Dengan jeda, animasi tidak akan berulang-ulang
        } // jika terus-terusan klik tombol E di keyboard.
    }
}