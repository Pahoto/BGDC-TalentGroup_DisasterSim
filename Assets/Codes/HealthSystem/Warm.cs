using UnityEngine;
using HealthSystem;
public class Warm : MonoBehaviour
{
    public PlayerHealth playerHealth = null;
    public Hypothermia hypothermia = null;
    public bool isHealing = false;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        hypothermia = FindObjectOfType<Hypothermia>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "FPS Player")
        {
            hypothermia.coldMeter.SetActive(false);
            hypothermia.ResetMeter();
            hypothermia.enabled = false;
            isHealing = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "FPS Player")
        {
            hypothermia.coldMeter.SetActive(true);
            hypothermia.enabled = true;
            isHealing = false;
        }
    }
    void FixedUpdate()
    {
        if (isHealing) playerHealth.Heal(Time.deltaTime);
    }
}