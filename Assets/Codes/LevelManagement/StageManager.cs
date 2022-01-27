using UnityEngine;
using UnityEngine.SceneManagement;
namespace StageSystem
{
    public class StageManager : MonoBehaviour
    {
        bool stageCompleted = false;
        float loadingTime = 15f;
        float restartTime = 5f;
        int currStageIdx = 0;
        int nextStageIdx = 0;
        public SceneTransition sceneTransition = null;
        void Start()
        {
            sceneTransition = FindObjectOfType<SceneTransition>();
            currStageIdx = SceneManager.GetActiveScene().buildIndex;
            nextStageIdx = SceneManager.GetActiveScene().buildIndex + 1;
        }
        void NextStage()
        {
            SceneManager.LoadScene(nextStageIdx);
        }
        void ReloadStage()
        {
            SceneManager.LoadScene(currStageIdx);
        }
        public void RestartStage()
        {
            Invoke("ReloadStage", restartTime);
        }
        public void EndStage()
        {
            if (!stageCompleted)
            {
                stageCompleted = true;
                sceneTransition.LoadingScreen();
                Invoke("NextStage", loadingTime);
            }
        }
    }
}