using UnityEngine;
public class MainMenu : MonoBehaviour
{
    public SceneTransition sceneTransition = null;
    void Start()
    {
        sceneTransition = FindObjectOfType<SceneTransition>();
    }
    public void NewGame()
    {
        sceneTransition.Call();
    }
    public void Exit()
    {
        Application.Quit();
    }
}