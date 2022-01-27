using UnityEngine;
public class DeathTrap : MonoBehaviour
{
    public Rigidbody boxRb = null;
    bool firstTry = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "FPS Player" && !firstTry)
        {
            boxRb.AddForce(0, 320f, 400f);
            firstTry = true;
        }
    }
}