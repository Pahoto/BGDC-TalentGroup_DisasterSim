using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueCollisionChecker : MonoBehaviour
{
    //private GameObject[] dialogueBoxes;
    public GameObject textBox;
    public GameObject textContent;

    public GameObject dialogueKey1;
    public Crosshair crosshair = null;

    public Image blackScreen;
    public RawImage theImage;
    private Text theText;
    public Texture[] dialogueImages = new Texture[3];
    private int currentImage;

    private int dialogue0;
    private int dialogue1;
    private int dialogue2;
    private int dialogue3;
    private bool dialogue1key;
    private bool dialogue2key;
    private bool dialogue3key;

    void Awake()
    {
        //dialogueBoxes = GameObject.FindGameObjectsWithTag("Dialogue Trigger");
        //foreach (GameObject dialogueBox in dialogueBoxes)
        //{
        //    dialogueBox.transform.localScale = new Vector3(0, 0, 0);
        //}

        StartCoroutine(HideDialogueBox(0f));
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogue0 = 0;
        dialogue1 = 0;
        dialogue2 = 0;
        dialogue3 = 0;
        dialogue1key = false;
        dialogue2key = false;
        dialogue3key = false;
        currentImage = 0;

        theText = textContent.GetComponent<Text>();
        theImage.texture = dialogueImages[currentImage];

        // Player Movement
        GetComponent<PlayerMovement>().enabled = false;

        // For Dialgoue
        StartCoroutine(Timer(2f, 0, 0, "Hey, wake up! You need to go, right?"));
        StartCoroutine(ShowDialogueBox(3f));

        crosshair = FindObjectOfType<Crosshair>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning == false && dialogue0 == 1)
        {
            StartCoroutine(Timer(3f, 0, 2, "5 minutes..."));
        }
        else if (timerRunning == false && dialogue0 == 2)
        {
            StartCoroutine(Timer(2.5f, 0, 0, "What? No, you can not, you have to go now!"));
        }
        else if (timerRunning == false && dialogue0 == 3)
        {
            StartCoroutine(FadeBlackIn(2));
            StartCoroutine(Timer(5f, 0, 2, "Where are we going?"));
        }
        else if (timerRunning == false && dialogue0 == 4)
        {
            StartCoroutine(Timer(3f, 0, 0, "Where are we going...? What!? DonÅft you remember? Were not you the one who told me to prepare for today? What has happened to you?"));
        }
        else if (timerRunning == false && dialogue0 == 5)
        {
            StartCoroutine(Timer(6f, 0, 2, "Wait, who are you?"));
        }
        else if (timerRunning == false && dialogue0 == 6)
        {
            StartCoroutine(Timer(3f, 0, 0, "Wait... You do not remember anything? Do, you do not even remember me, your very-very-very-very precious and lovely robot?"));
        }
        else if (timerRunning == false && dialogue0 == 7)
        {
            StartCoroutine(Timer(9.5f, 0, 1, "If you do not remember anything, then I will teach you something basic. You can walk with [W] [A] [S] and [D]. [W] for moving forward, [S] for moving backward, [A] for moving to the left, and [D] for moving to the right. You can also jump with the [SPACE] button."));
        }
        else if (timerRunning == false && dialogue0 == 8)
        {
            StartCoroutine(Timer(13f, 0, 0, "Now, try to move!"));
        }
        else if (timerRunning == false && dialogue0 == 9)
        {
            GetComponent<PlayerMovement>().enabled = true;
            dialogue0++;
        }

        if(dialogue1key == true && dialogue1 == 1)
        {
            StartCoroutine(ShowDialogueBox(0f));
            StartCoroutine(Timer(0f, 1, 1, "Hmm.. it turns out that you are smart enough."));
        }
        else if (timerRunning == false && dialogue1 == 2)
        {
            StartCoroutine(Timer(4f, 1, 0, "Now, as I said before, you need to go! Go to your grandmaÅfs house, I will lead you!"));
        }
        else if (timerRunning == false && dialogue1 == 3)
        {
            StartCoroutine(Timer(6f, 1, 0, "Let us start with getting out of this room first. You can open a door with the [E] button. The door is there beside the curtain."));
        }
        else if (timerRunning == false && dialogue1 == 4)
        {
            StartCoroutine(HideDialogueBox(8f));
            dialogue1++;
        }

        if (!crosshair.isCardObtained)
        {
            if (dialogue2key == true && dialogue2 == 1 && Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(ShowDialogueBox(0f));
                StartCoroutine(Timer(0f, 2, 2, "The door doesnÅft open!  WhereÅfs the key?"));
            }
            else if (timerRunning == false && dialogue2 == 2)
            {
                StartCoroutine(Timer(4f, 2, 0, "How do I know, you donÅft remember that you have a habit of keeping your key in a different locker? Now you donÅft remember where you put the key-"));
            }
            else if (timerRunning == false && dialogue2 == 3)
            {
                StartCoroutine(Timer(7.5f, 2, 2, "Sttt.. youÅfre so noisy."));
            }
            else if (timerRunning == false && dialogue2 == 4)
            {
                StartCoroutine(Timer(2.5f, 2, 0, "WHAT!?"));
            }
            else if (timerRunning == false && dialogue2 == 5)
            {
                StartCoroutine(Timer(1f, 2, 1, "Alright, I will shut my mouth up. You better find the key quickly. You can interact with it or any items with the [F] button."));
            }
            else if (timerRunning == false && dialogue2 == 6)
            {
                StartCoroutine(HideDialogueBox(8.5f));
                dialogue2++;
            }
        }

        if (crosshair.isCardObtained && dialogue3 == 0 && dialogue3key == false)
        {
            dialogue3key = true;
        }

        if (timerRunning == false && dialogue3key == true && dialogue3 == 0)
        {
            StartCoroutine(ShowDialogueBox(0f));
            StartCoroutine(Timer(0f, 3, 2, "Is this the key?"));
        }
        else if (timerRunning == false && dialogue3 == 1)
        {
            StartCoroutine(Timer(1.75f, 3, 1, "Wow, you actually found the key!"));
        }
        else if (timerRunning == false && dialogue3 == 2)
        {
            StartCoroutine(Timer(2f, 3, 1, "Now, letÅfs go out!"));
        }
        else if (timerRunning == false && dialogue3 == 3)
        {
            StartCoroutine(HideDialogueBox(2f));
            dialogue3++;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Dialogue Collider 1" && dialogue1 == 0)
        {
            dialogue1key = true;
            dialogue1 = 1;
        }

        if (other.gameObject.name == "Dialogue Collider 2" && dialogue2 == 0)
        {
            dialogue2key = true;
            dialogue2 = 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Dialogue Collider 2" && dialogue2 == 1)
        {
            dialogue2 = 0;
        }
    }

    // Timer & Dialogue Changes
    private bool timerRunning = false;
    IEnumerator Timer(float time, int dialogueNumber, int changeImage, string dialogue)
    {
        timerRunning = true;
        yield return new WaitForSeconds(time);
        if (dialogueNumber == 0) dialogue0++;
        else if (dialogueNumber == 1) dialogue1++;
        else if (dialogueNumber == 2) dialogue2++;
        else if (dialogueNumber == 3) dialogue3++;
        timerRunning = false;
        if (changeImage != -1)
        {
            theImage.texture = dialogueImages[changeImage];
            theText.text = dialogue;
        }
    }

    IEnumerator FadeBlackIn(int fadeSpeed, float fadeTo = 0)
    {
        Color objectColor = blackScreen.GetComponent<Image>().color;
        float fadeAmount;

        while (blackScreen.GetComponent<Image>().color.a > fadeTo)
        {
            fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            blackScreen.GetComponent<Image>().color = objectColor;

            yield return null;
        }
    }

    IEnumerator FadeBlackOut(int fadeSpeed, float fadeTo = 1)
    {
        Color objectColor = blackScreen.GetComponent<Image>().color;
        float fadeAmount;

        while (blackScreen.GetComponent<Image>().color.a < fadeTo)
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
