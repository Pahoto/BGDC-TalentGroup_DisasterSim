using UnityEngine;
using StageSystem;
public class SceneTransition : MonoBehaviour
{
    public StageManager stageManager = null;
    public GameObject loading = null;
    public Animator loadTMP = null;
    
    void Start()
    {
        stageManager = FindObjectOfType<StageManager>();
        loading.SetActive(false);
    }
    void Call()
    {
        stageManager.EndStage();
    }
    public void LoadingScreen()
    {
        loading.SetActive(true);
        loadTMP.Play("Load TMP", 0, 0.1f);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "FPS Player") Invoke("Call", 2f);
    }
}