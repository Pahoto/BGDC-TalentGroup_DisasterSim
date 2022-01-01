using UnityEngine;
using HealthSystem;
public class Electrocuted : MonoBehaviour
{
    bool isElectrocuted = false;
    public PlayerHealth playerHealth = null;
    public GameObject electric = null;
    
        void OnTriggerEnter(Collider other)
    {
        if (other.name == "FPS Player")
        {
            electric.SetActive(true);
            isElectrocuted = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "FPS Player")
        {
            electric.SetActive(false);
            isElectrocuted = false;
        }
    }
    void FixedUpdate()
    {
        if (isElectrocuted) playerHealth.TakeDamage(Time.deltaTime);
    }
}