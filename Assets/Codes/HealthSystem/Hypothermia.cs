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
        if (other.name == "FPS Player")
        {
            coldMeter.SetActive(true);
            isCold = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "FPS Player")
        {
            coldMeter.SetActive(false);
            isCold = false;
        }
    }
    IEnumerator PauseInteraction()
    {
        pauseInteraction = true;
        coldSlider.value = ++i;
        if (i == lastSec) playerHealth.TakeDamage(5f);
        yield return new WaitForSeconds(1f);
        pauseInteraction = false;
    }
    public void ResetMeter()
    {
        coldSlider.value = i = firstSec;
    }
    void Update()
    {
        if (!isCold || i > lastSec) ResetMeter();
        else if (!pauseInteraction) StartCoroutine(PauseInteraction());
    }
}