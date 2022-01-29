using UnityEngine;
using System.Collections;
public class KeyDoor : MonoBehaviour
{
    public Animator doorAnim = null;
    public Animator sensorAnim = null;

    public bool doorTriggered = false;
    public bool openingDoor = false;
    public bool pauseInteraction = false;

    public Crosshair crosshair = null;
    public bool unlockDoor = false;

    public AudioSource openSound = null;
    public AudioSource closeSound = null;

    void Start()
    {
        crosshair = FindObjectOfType<Crosshair>();
        closeSound = GetComponentInParent<AudioSource>();
    }

    void OnTriggerEnter(Collider approachingCollider)
    {
        if (approachingCollider.name == "Crosshair") doorTriggered = true;
    }

    void OnTriggerExit(Collider leavingCollider)
    {
        if (leavingCollider.name == "Crosshair") doorTriggered = false;
    }
    
    IEnumerator PauseInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(1f);
        pauseInteraction = false;
    }
    
    void Update()
    {
        if (doorTriggered && Input.GetKeyDown(KeyCode.E))
        {
            if (crosshair.isCardObtained) unlockDoor = true;
            if (unlockDoor && !pauseInteraction)
            {
                if (!openingDoor)
                {
                    doorAnim.Play("New Door Open", 0, 0f);
                    sensorAnim.Play("New Door Open", 0, 0f);
                    openSound.Play();
                    openingDoor = true;
                    StartCoroutine(PauseInteraction());
                }
                else
                {
                    doorAnim.Play("New Door Close", 0, 0f);
                    sensorAnim.Play("New Door Close", 0, 0f);
                    closeSound.Play();
                    openingDoor = false;
                    StartCoroutine(PauseInteraction());
                }
            }
        }
    }
}