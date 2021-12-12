using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueCollisionChecker : MonoBehaviour
{
    private GameObject[] dialogueBoxes;
    public GameObject textBox;
    public GameObject textContent;
    private Text theText;

    void Awake()
    {
        dialogueBoxes = GameObject.FindGameObjectsWithTag("Dialogue Trigger");
        foreach(GameObject dialogueBox in dialogueBoxes)
        {
            dialogueBox.transform.localScale = new Vector3(0, 0, 0);
        }

        textBox.transform.localScale = new Vector3(0, 0, 0);
        textContent.transform.localScale = new Vector3(0, 0, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        theText = textContent.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Dialogue Collider 1")
        {
            textBox.transform.localScale = new Vector3(1, 1, 1);
            textContent.transform.localScale = new Vector3(1, 1, 1);

            theText.text = "Yeahhh!!!";
        }
    }
<<<<<<< Updated upstream
}
=======
}
>>>>>>> Stashed changes
