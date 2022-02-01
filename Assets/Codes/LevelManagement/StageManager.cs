using UnityEngine;
using UnityEngine.SceneManagement;
namespace StageSystem
{
    public class StageManager : MonoBehaviour
    {
        public float loadingTime = 15f;
        float restartTime = 5f;
        int menuIdx = 0;
        int currStageIdx = 0;
        int nextStageIdx = 0;
        public SceneTransition sceneTransition = null;
        void Start()
        {
            sceneTransition = FindObjectOfType<SceneTransition>();
            currStageIdx = SceneManager.GetActiveScene().buildIndex;
            nextStageIdx = currStageIdx + 1;
        }
        void NextStage()
        {
            SceneManager.LoadScene(nextStageIdx);
        }
        public void EndStage()
        {
            sceneTransition.LoadingScreen();
            Invoke("NextStage", loadingTime);
        }
        void ReloadStage()
        {
            SceneManager.LoadScene(currStageIdx);
        }
        public void RestartStage()
        {
            Invoke("ReloadStage", restartTime);
        }
        public void ExitStage()
        {
            SceneManager.LoadScene(menuIdx);
        }
    }
}