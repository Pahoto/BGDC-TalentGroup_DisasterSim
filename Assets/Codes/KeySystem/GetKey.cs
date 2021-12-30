using UnityEngine;
namespace KeySystem
{
    public class GetKey : MonoBehaviour
    {
        public Animator keyAnim = null;
        public bool keyTake = false;
        void Start()
        {
            keyAnim.Play("Item Rotation", 0, 0.5f);
        }
        void OnTriggerEnter(Collider approachingCollider)
        {
            if (approachingCollider.name == "FPS Player")
            {
                keyTake = true;
                Destroy(gameObject);
            }
        }
    }
}