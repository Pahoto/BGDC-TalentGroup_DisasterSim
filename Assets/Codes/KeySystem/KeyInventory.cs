using UnityEngine;
namespace KeySystem
{
    public class KeyInventory : MonoBehaviour
    {
        public int totalKey = 0;
        public GetKey[] getKey = new GetKey[3];

        bool addKey = false;
        bool[] keyAdded = new bool[3];

        public bool obtainedKey = false;

        bool[] decreasedKey = new bool[3];
        public Locker[] locker = new Locker[3];

        int i = 0;
        int j = 0;

        void Update()
        {
            for (i = 0; i < 1; i++)
            {
                if (getKey[i].keyTake)
                {
                    if (!keyAdded[i])
                    {
                        totalKey++;
                        keyAdded[i] = true;
                    }
                }
            }

            if (totalKey > 0) obtainedKey = true;
            else obtainedKey = false;

            for (j = 0; j < 1; j++)
            {
                if (locker[j].usedKey)
                {
                    if (!decreasedKey[j] && obtainedKey)
                    {
                        totalKey--;
                        decreasedKey[j] = true;
                    }
                }
            }
        }
    }
}