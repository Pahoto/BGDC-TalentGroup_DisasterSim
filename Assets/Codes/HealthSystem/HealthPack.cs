using UnityEngine;
using HealthSystem;
public class HealthPack : MonoBehaviour
{
    public PlayerHealth playerHealth = null;
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "FPS Player")
        {
            playerHealth.Heal(50f);
            Destroy(this.gameObject);
        }
    }
}