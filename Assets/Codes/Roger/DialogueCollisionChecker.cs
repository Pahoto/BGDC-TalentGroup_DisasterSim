using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueCollisionChecker : MonoBehaviour
{
    private GameObject[] dialogueBoxes;
    public GameObject textBox;
    public GameObject textContent;

    public RawImage theImage;
    private Text theText;
    public Texture[] dialogueImages = new Texture[3];
    private int currentImage;

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
        currentImage = 0;

        theText = textContent.GetComponent<Text>();
        theImage.texture = dialogueImages[currentImage];

        // For Dialgoue
        theText.text = "Hey, wake up! You need to go, right?";
        StartCoroutine(Timer(4f, 0, 2));
    }

    // Update is called once per frame
    void Update()
    {
        if(timerRunning == false && dialogue0 == 1)
        {
            theText.text = "5 minute...";
            StartCoroutine(Timer(2.5f, 0, 0));
        }
        else if(timerRunning == false && dialogue0 == 2)
        {
            theText.text = "What? No, you can't, you have to go now!";
            StartCoroutine(Timer(5f, 0, 2));
        }
        else if (timerRunning == false && dialogue0 == 3)
        {
            theText.text = "Where are we going?";
            StartCoroutine(Timer(3f, 0, 0));
        }
        else if (timerRunning == false && dialogue0 == 4)
        {
            theText.text = "Where are we going...? What!? DonÅft you remember? WerenÅft you the one who told me to prepare for today? What has happened to you?";
            StartCoroutine(Timer(10f, 0, -1));
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
    private bool timerRunning = false;
    IEnumerator Timer(float time, int dialogueNumber, int changeImage)
    {
        timerRunning = true;
        yield return new WaitForSeconds(time);
        if (dialogueNumber == 0) dialogue0++;
        timerRunning = false;
        if(changeImage != -1)
        {
            theImage.texture = dialogueImages[changeImage];
        }
    }
}
