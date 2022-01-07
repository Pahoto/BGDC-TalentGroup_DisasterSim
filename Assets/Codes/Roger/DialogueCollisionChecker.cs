using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueCollisionChecker : MonoBehaviour
{
    private GameObject[] dialogueBoxes;
    public GameObject textBox;
    public GameObject textContent;

    public Image blackScreen;
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

        StartCoroutine(HideDialogueBox(0f));
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
        StartCoroutine(Timer(2f, 0, 0, "Hey, wake up! You need to go, right?"));
        StartCoroutine(ShowDialogueBox(2f));
    }

    // Update is called once per frame
    void Update()
    {
        if(timerRunning == false && dialogue0 == 1)
        {
            StartCoroutine(Timer(2f, 0, 2, "5 minutes..."));
        }
        else if(timerRunning == false && dialogue0 == 2)
        {
            StartCoroutine(Timer(2.5f, 0, 0, "What? No, you can't, you have to go now!"));
        }
        else if (timerRunning == false && dialogue0 == 3)
        {
            StartCoroutine(FadeBlackIn(2));
            StartCoroutine(Timer(5f, 0, 2, "Where are we going?"));
        }
        else if (timerRunning == false && dialogue0 == 4)
        {
            StartCoroutine(Timer(3f, 0, 0, "Where are we going...? What!? DonÅft you remember? WerenÅft you the one who told me to prepare for today? What has happened to you?"));
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

    // Timer & Dialogue Changes
    private bool timerRunning = false;
    IEnumerator Timer(float time, int dialogueNumber, int changeImage, string dialogue)
    {
        timerRunning = true;
        yield return new WaitForSeconds(time);
        if (dialogueNumber == 0) dialogue0++;
        timerRunning = false;
        if(changeImage != -1)
        {
            theImage.texture = dialogueImages[changeImage];
            theText.text = dialogue;
        }
    }

    IEnumerator FadeBlackIn(int fadeSpeed)
    {
        Color objectColor = blackScreen.GetComponent<Image>().color;
        float fadeAmount;

        while (blackScreen.GetComponent<Image>().color.a > 0)
        {
            fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            blackScreen.GetComponent<Image>().color = objectColor;

            yield return null;
        }
    }

    IEnumerator FadeBlackOut(int fadeSpeed)
    {
        Color objectColor = blackScreen.GetComponent<Image>().color;
        float fadeAmount;

        while (blackScreen.GetComponent<Image>().color.a < 1)
        {
            fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            blackScreen.GetComponent<Image>().color = objectColor;

            yield return null;
        }
    }

    IEnumerator HideDialogueBox(float wait = 0f)
    {
        yield return new WaitForSeconds(wait);

        textBox.transform.localScale = new Vector3(0, 0, 0);
        textContent.transform.localScale = new Vector3(0, 0, 0);
    }

    IEnumerator ShowDialogueBox(float wait = 0f)
    {
        yield return new WaitForSeconds(wait);

        textBox.transform.localScale = new Vector3(1, 1, 1);
        textContent.transform.localScale = new Vector3(1, 1, 1);
    }
}
