using UnityEngine;
using UnityEngine.UI;
using StageSystem;
public class SceneTransition : MonoBehaviour
{
    bool touchCard = false;
    public GameObject keyCard = null;
    public Crosshair crosshair = null;

    public StageManager stageManager = null;
    public GameObject loading = null;
    public Animator loadTextAnim = null;

    void Start()
    {
        crosshair = FindObjectOfType<Crosshair>();
        stageManager = FindObjectOfType<StageManager>();
        loading.SetActive(false);
    }
    public void LoadingScreen()
    {
        loading.SetActive(true);
        loadTextAnim.Play("Load Text Anim", 0, 0.1f);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Crosshair" && !crosshair.isTouched)
        {
            crosshair.isTouched = true;
            touchCard = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Crosshair")
        {
            crosshair.isTouched = false;
            touchCard = false;
        }
    }
    void Update()
    {
        if (touchCard && Input.GetKeyDown(KeyCode.E)) stageManager.EndStage();
    }
}