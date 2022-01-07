using UnityEngine;
using System.Collections;
using KeySystem;
public class Locker : MonoBehaviour
{
    public Animator lockerAnim = null;
    public Animator sensorAnim = null;
    public bool lockerTriggered = false;
    public bool openingLocker = false;
    public bool pauseInteraction = false;

    public KeyInventory keyInventory = null;
    public bool hasKey = false;
    public bool unlockLocker = false;
    public bool usedKey = false;

    void OnTriggerEnter(Collider approachingCollider)
    {
        if (approachingCollider.name == "Crosshair") lockerTriggered = true;
    }
    void OnTriggerExit(Collider leavingCollider)
    {
        if (leavingCollider.name == "Crosshair") lockerTriggered = false;
    }
    IEnumerator PauseInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(1f);
        pauseInteraction = false;
    }
    void Update()
    {
        if (unlockLocker || !keyInventory.obtainedKey)
        {
            hasKey = false;
            if (unlockLocker) usedKey = true;
        }
        else if (keyInventory.obtainedKey) hasKey = true;

        if (lockerTriggered && Input.GetKeyDown(KeyCode.E))
        {
            if (hasKey) unlockLocker = true;
            if (unlockLocker && !pauseInteraction)
            {
                if (!openingLocker)
                {
                    lockerAnim.Play("Locker Open", 0, 0f);
                    sensorAnim.Play("Locker Open", 0, 0f);
                    openingLocker = true;
                    StartCoroutine(PauseInteraction());
                }
                else
                {
                    lockerAnim.Play("Locker Close", 0, 0f);
                    sensorAnim.Play("Locker Close", 0, 0f);
                    openingLocker = false;
                    StartCoroutine(PauseInteraction());
                }
            }
        }
    }
}