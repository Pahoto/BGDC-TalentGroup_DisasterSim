using UnityEngine;
public class KeyCard : MonoBehaviour
{
    public bool isCardTouched = false;
    public Crosshair crosshair = null;
    public GameObject keyCard = null;
    public AudioSource getItemSound = null;
    void Start()
    {
        crosshair = FindObjectOfType<Crosshair>();
        getItemSound = gameObject.GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Crosshair") isCardTouched = true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Crosshair") isCardTouched = false;
    }
    void Update()
    {
        if (isCardTouched && Input.GetKeyDown(KeyCode.F))
        {
            crosshair.isCardObtained = true;
            getItemSound.Play();
            Destroy(keyCard);
        }
    }
}