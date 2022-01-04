using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace StageSystem
{
    public class StageManager : MonoBehaviour
    {
        bool stageCompleted = false;
        float loadingTime = 15f;
        float restartTime = 5f;
        string stage1Name = "backupv10-L2-Stage1";
        public SceneTransition sceneTransition = null;
        void Start()
        {
            sceneTransition = FindObjectOfType<SceneTransition>();
        }
        void LoadStage()
        {
            SceneManager.LoadScene(stage1Name);
        }
        public void RestartStage()
        {
            Invoke("LoadStage", restartTime);
        }
        public void EndStage()
        {
            if (!stageCompleted)
            {
                stageCompleted = true;
                sceneTransition.LoadingScreen();
                Invoke("LoadStage", loadingTime);
            }
        }
    }
}