using UnityEngine;
using System.Collections;
namespace KeySystem
{
    public class OpenLocker : MonoBehaviour
    {
        public Animator lockerAnim = null;
        public Animator sensorAnim = null;
        public bool lockerTriggered = false;
        public bool openingLocker = false;
        public bool pauseInteraction = false;
        // Untuk arahin loker yang mau dibuka:
        public Crosshair crosshair = null;
        // Untuk audio / sound:
        public AudioSource openSound = null;
        public AudioSource closeSound = null;
        void Start()
        {
            crosshair = FindObjectOfType<Crosshair>();
            closeSound = GetComponentInParent<AudioSource>();
        }

        void OnTriggerEnter(Collider approachingCollider)
        {
            if (approachingCollider.name == "Crosshair" && !crosshair.isTouched)
            {
                crosshair.isTouched = true;
                lockerTriggered = true;
            }
        }
        void OnTriggerExit(Collider leavingCollider)
        {
            if (leavingCollider.name == "Crosshair")
            {
                if (crosshair.isTouched) crosshair.isTouched = false;
                lockerTriggered = false;
            }
        }
        IEnumerator PauseInteraction()
        {
            pauseInteraction = true;
            yield return new WaitForSeconds(1f);
            pauseInteraction = false;
        }
        void Update()
        {
            if (lockerTriggered && Input.GetKeyDown(KeyCode.E) && !pauseInteraction)
            {
                if (!openingLocker)
                {
                    lockerAnim.Play("Locker Open", 0, 0f);
                    sensorAnim.Play("Locker Open", 0, 0f);
                    openSound.Play();
                    openingLocker = true;
                    StartCoroutine(PauseInteraction());
                }
                else
                {
                    lockerAnim.Play("Locker Close", 0, 0f);
                    sensorAnim.Play("Locker Close", 0, 0f);
                    closeSound.Play();
                    openingLocker = false;
                    StartCoroutine(PauseInteraction());
                }
            }
        }
    }
}