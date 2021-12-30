using UnityEngine;
using HealthSystem;
public class Electrocuted : MonoBehaviour
{
    bool isElectrocuted = false;
    public PlayerHealth playerHealth = null;
    public GameObject electric = null;
    
        void OnTriggerEnter(Collider other)
    {
        if (other.name == "FPS Player") isElectrocuted = true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "FPS Player") isElectrocuted = false;
    }
    void FixedUpdate()
    {
        if (isElectrocuted)
        {
            electric.SetActive(true);
            playerHealth.TakeDamage(Time.deltaTime);
        }
        else electric.SetActive(false);
    }
}