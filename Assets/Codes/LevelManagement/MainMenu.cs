using UnityEngine;
using StageSystem;
public class MainMenu : MonoBehaviour
{
    public StageManager stageManager = null;
    public SceneTransition sceneTransition = null;
    public GameObject menuContent = null;
    public GameObject creditsContent = null;
    bool isGameStarted = false;
    public AudioSource menuMusic = null;
    void CallMainMenu()
    {
        sceneTransition.loading.SetActive(false);
        menuContent.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        menuMusic.Play();
    }
    void Start()
    {
        stageManager = FindObjectOfType<StageManager>();
        sceneTransition = FindObjectOfType<SceneTransition>();
        menuMusic = gameObject.GetComponent<AudioSource>();
        creditsContent.SetActive(false);
        menuContent.SetActive(false);
    }
    public void NewGame()
    {
        stageManager.EndStage();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    void Update()
    {
        if (!isGameStarted)
        {
            sceneTransition.LoadingScreen();
            Invoke("CallMainMenu", stageManager.loadingTime);
            isGameStarted = true;
        }
    }
}