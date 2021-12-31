using UnityEngine;
public class TakeKey : MonoBehaviour
{
    public GameObject player = null;
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Crosshair" && Input.GetKeyDown(KeyCode.E))
        {
            player.transform.position = new Vector3(141f, 2.847728f, -37.83f);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Crosshair")
        {
            gameObject.SetActive(false);
        }
    }
}