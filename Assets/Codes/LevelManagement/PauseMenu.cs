using UnityEngine;
using StageSystem;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI = null;
    bool isGamePaused = false;
    public StageManager stageManager = null;
    void Start()
    {
        pauseUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        stageManager = FindObjectOfType<StageManager>();
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        isGamePaused = true;
        pauseUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
    public void ContinueGame()
    {
        pauseUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    public void QuitGame()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        stageManager.ExitStage();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGamePaused) PauseGame();
            else ContinueGame();
        }
    }
}