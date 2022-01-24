using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabletHandler : MonoBehaviour
{
    public Crosshair crosshair = null;
    public GameObject tablet;
    public GameObject player;

    private bool tabletTriggered = false;
    private bool takeTablet = false;
    private bool pauseInteraction = false;

    public Image blackScreen;
    public RawImage puzzle;

    // Start is called before the first frame update
    void Start()
    {
        tablet.transform.localScale = new Vector3(0, 0, 0);
        puzzle.transform.localScale = new Vector3(0, 0, 0);
    }

    void OnTriggerEnter(Collider approachingCollider)
    {
        if (approachingCollider.name == "Crosshair" && !crosshair.isTouched)
        {
            crosshair.isTouched = true;
            tabletTriggered = true;
        }
    }

    void OnTriggerExit(Collider leavingCollider)
    {
        if (leavingCollider.name == "Crosshair")
        {
            if (crosshair.isTouched) crosshair.isTouched = false;
            tabletTriggered = false;
        }
    }

    IEnumerator PauseInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(1f);
        pauseInteraction = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (tabletTriggered && Input.GetKeyDown(KeyCode.F) && pauseInteraction == false)
        {
            StartCoroutine(ShowTablet());
            StartCoroutine(HideCrosshiar());
            StartCoroutine(PauseInteraction());
            takeTablet = true;
            player.GetComponent<PlayerMovement>().enabled = false;
        }
        if (takeTablet && Input.GetKeyDown(KeyCode.F) && pauseInteraction == false)
        {
            StartCoroutine(HideTablet());
            StartCoroutine(ShowCrosshiar());
            StartCoroutine(PauseInteraction());
            takeTablet = false;
            player.GetComponent<PlayerMovement>().enabled = true;
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

    IEnumerator HideCrosshiar(float wait = 0f)
    {
        yield return new WaitForSeconds(wait);

        crosshair.transform.localScale = new Vector3(0, 0, 0);
    }

    IEnumerator ShowCrosshiar(float wait = 0f)
    {
        yield return new WaitForSeconds(wait);

        crosshair.transform.localScale = new Vector3(0.005900105f, 0.6064827f, 0.005467311f);
    }

    IEnumerator HideTablet(float wait = 0f)
    {
        yield return new WaitForSeconds(wait);
        tablet.transform.localScale = new Vector3(0, 0, 0);
        puzzle.transform.localScale = new Vector3(0, 0, 0);
    }

    IEnumerator ShowTablet(float wait = 0f)
    {
        yield return new WaitForSeconds(wait);

        tablet.transform.localScale = new Vector3(28.91671f, 1.650508f, 28.91668f);
        puzzle.transform.localScale = new Vector3(1, 1, 1);
    }
}
