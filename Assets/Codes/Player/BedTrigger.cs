using UnityEngine;
public class BedTrigger : MonoBehaviour
{
    public bool onBed = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "FPS Player") onBed = true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "FPS Player") onBed = false;
    }
}