using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using HealthSystem;
public class Hypothermia : MonoBehaviour
{
    public bool isCold = false;
    public bool pauseInteraction = false;

    public PlayerHealth playerHealth = null;
    public GameObject coldMeter = null;
    public Slider coldSlider = null;

    int i = 0;
    int firstSec = 0;
    int lastSec = 15;

    void Start()
    {
        coldSlider.minValue = firstSec;
        coldSlider.maxValue = lastSec;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "FPS Player") isCold = true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "FPS Player") isCold = false;
    }
    IEnumerator PauseInteraction()
    {
        pauseInteraction = true;
        coldSlider.value = ++i;
        if (i == lastSec) playerHealth.TakeDamage(5f);
        yield return new WaitForSeconds(1f);
        pauseInteraction = false;
    }
    void Update()
    {
        if (!isCold || i > lastSec)
        {
            if (!isCold) coldMeter.SetActive(false);
            coldSlider.value = i = firstSec;
        }
        else
        {
            coldMeter.SetActive(true);
            if (!pauseInteraction) StartCoroutine(PauseInteraction());
        }
    }
}