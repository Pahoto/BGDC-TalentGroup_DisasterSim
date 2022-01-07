using UnityEngine;
using HealthSystem;
public class InstaDeath : MonoBehaviour
{
    public PlayerHealth playerHealth = null;
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "FPS Player") playerHealth.TakeDamage(100f);
    }
}