using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using StageSystem;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI = null;
    bool isGamePaused = false;
    public StageManager stageManager = null;
    public AudioSource buttonSound = null;
    public AudioMixer audioMixer = null;
    public AudioListener audioListener = null;
    public Slider volumeSlider = null;
    void SetVolSlider()
    {
        volumeSlider.value = 0f;
        volumeSlider.minValue = -80f;
        volumeSlider.maxValue = 20f;
        volumeSlider.value = PlayerPrefs.GetFloat("saveSliderValue");
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        stageManager = FindObjectOfType<StageManager>();
        audioListener = FindObjectOfType<AudioListener>();
        SetVolSlider();
        pauseUI.SetActive(false);
    }
    public void VolumeSlider(float sliderValue)
    {
        // Mengatur nilai volume Master pada AudioMixer.
        audioMixer.SetFloat("masterVolume", sliderValue);
        // Agar sesuai dengan (pergeseran) nilai Slider.
        PlayerPrefs.SetFloat("saveSliderValue1", sliderValue);
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
            if (!isGamePaused)
            {
                buttonSound.Play();
                audioListener.enabled = false;
                PauseGame();
            }
            else
            {
                audioListener.enabled = true;
                buttonSound.Play();
                ContinueGame();
            }
        }
    }
}