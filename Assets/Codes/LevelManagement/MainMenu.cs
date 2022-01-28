using UnityEngine;
using StageSystem;
public class MainMenu : MonoBehaviour
{
    public StageManager stageManager = null;
    public SceneTransition sceneTransition = null;
    public GameObject menuContent = null;
    bool isGameStarted = false;
    void CallMainMenu()
    {
        sceneTransition.loading.SetActive(false);
        menuContent.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        stageManager = FindObjectOfType<StageManager>();
    }
    void Start()
    {
        sceneTransition = FindObjectOfType<SceneTransition>();
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