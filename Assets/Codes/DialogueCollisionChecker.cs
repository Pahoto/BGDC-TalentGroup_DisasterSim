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

    private int dialogue0;
    private bool dialogue1key;

    void Awake()
    {
        dialogueBoxes = GameObject.FindGameObjectsWithTag("Dialogue Trigger");
        foreach(GameObject dialogueBox in dialogueBoxes)
        {
            dialogueBox.transform.localScale = new Vector3(0, 0, 0);
        }

        // textBox.transform.localScale = new Vector3(0, 0, 0);
        // textContent.transform.localScale = new Vector3(0, 0, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogue0 = 0;
        dialogue1key = false;

        theText = textContent.GetComponent<Text>();

        // For Dialgoue
        theText.text = "Hey, wake up! You need to go, right?";
        StartCoroutine(Timer(5f, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if(timerRuning == false && dialogue0 == 1)
        {
            theText.text = "5 minute...";
            StartCoroutine(Timer(5f, 0));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Dialogue Collider 1")
        {
            textBox.transform.localScale = new Vector3(1, 1, 1);
            textContent.transform.localScale = new Vector3(1, 1, 1);

            dialogue1key = true;
        }
    }

    // Timer
    private bool timerRuning = false;
    IEnumerator Timer(float time, int dialogueNumber)
    {
        timerRuning = true;
        yield return new WaitForSeconds(time);
        if (dialogueNumber == 0) dialogue0++;
        timerRuning = false;
    }
}
