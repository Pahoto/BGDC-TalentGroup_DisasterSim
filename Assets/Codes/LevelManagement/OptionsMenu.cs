using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections.Generic;
public class OptionsMenu : MonoBehaviour
{
    public Slider volSlider = null;
    public AudioMixer audioMixer = null;
    public Toggle fullScreenToggle = null;
    public Dropdown resolutionsDropdown = null;
    Resolution[] resoStorage = null;
    int i = 0;
    int totalReso = 0;
    int width = 0;
    int height = 0;
    int defaultOptionIdx = 0;
    string label = null;
    bool isFullScreen = false;
    void SetResoDropdown()
    {
        resolutionsDropdown.ClearOptions();
        resoStorage = Screen.resolutions;
        totalReso = resoStorage.Length;
        List<string> optionsList = new List<string>();
        for (i = 0; i < totalReso; i++)
        {
            width = resoStorage[i].width;
            height = resoStorage[i].height;
            label = width + " x " + height;
            optionsList.Add(label);
            if (
                width == Screen.currentResolution.width &&
                height == Screen.currentResolution.height
            ) defaultOptionIdx = i;
        }
        resolutionsDropdown.AddOptions(optionsList);
        resolutionsDropdown.value = defaultOptionIdx;
        resolutionsDropdown.RefreshShownValue();
        resolutionsDropdown.template.GetComponent<ScrollRect>().scrollSensitivity = 45f;
    }
    void SetVolSlider()
    {
        volSlider.value = 0f;
        volSlider.minValue = -80f;
        volSlider.maxValue = 20f;
        volSlider.value = PlayerPrefs.GetFloat("saveSliderValue1");
    }
    void Start()
    {
        SetVolSlider();
        SetResoDropdown();
        gameObject.SetActive(false);
    }
    public void VolumeSlider(float sliderValue)
    {
        // Mengatur nilai volume Master pada AudioMixer.
        audioMixer.SetFloat("masterVolume", sliderValue);
        // Agar sesuai dengan (pergeseran) nilai Slider.
        PlayerPrefs.SetFloat("saveSliderValue", sliderValue);
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
    public void ChooseResolution(int dropdownIdx)
    {
        Resolution reso = resoStorage[dropdownIdx];
        width = reso.width;
        height = reso.height;
        isFullScreen = Screen.fullScreen;
        Screen.SetResolution(width, height, isFullScreen);
    }
}