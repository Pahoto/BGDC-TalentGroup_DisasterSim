using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class OptionsMenu : MonoBehaviour
{
    public Slider volSlider = null;
    public AudioMixer audioMixer = null;
    public Toggle fullScreenToggle = null;
    void Start()
    {
        volSlider.minValue = -80f;
        volSlider.maxValue = 20f;
        gameObject.SetActive(false);
    }
    public void VolumeSlider(float sliderValue)
    {
        // Mengatur nilai volume Master pada AudioMixer.
        audioMixer.SetFloat("masterVolume", sliderValue);
        // Agar sesuai dengan (pergeseran) nilai Slider.
    }
    public void ChooseGraphics(int dropdownIdx)
    {
        // Mengatur preferensi grafik sesuai
        QualitySettings.SetQualityLevel(dropdownIdx);
        // dengan pilihan pada Dropdown ....
    }
    public void ToggleFullScreen(bool isToggleOn)
    {
        Screen.fullScreen = isToggleOn;
    }
}