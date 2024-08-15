using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;  // Add this if using TMP_Dropdown

public class settingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public TMP_Dropdown graphicsDropdown;  // Change to TMP_Dropdown if using TextMeshPro
    public Toggle fullscreenToggle;

    void Start()
    {
        InitializeSettings();
    }

    void OnEnable()
    {
        InitializeSettings();
    }

    void InitializeSettings()
    {
        // Load and apply the saved volume
        if (PlayerPrefs.HasKey("StoredVolume"))
        {
            float storedVolume = PlayerPrefs.GetFloat("StoredVolume");
            if (volumeSlider != null)
            {
                volumeSlider.value = Mathf.Pow(10, storedVolume / 20); // Convert dB back to linear
            }
            audioMixer.SetFloat("volume", storedVolume);
        }

        // Load and apply the saved graphics quality
        if (PlayerPrefs.HasKey("StoredQuality"))
        {
            int qualityIndex = PlayerPrefs.GetInt("StoredQuality");
            QualitySettings.SetQualityLevel(qualityIndex);
            if (graphicsDropdown != null)
            {
                graphicsDropdown.value = qualityIndex;
                graphicsDropdown.RefreshShownValue();  // Ensure the dropdown shows the correct value
            }
        }

        // Load and apply the saved fullscreen mode
        if (PlayerPrefs.HasKey("StoredFullscreen"))
        {
            //     bool isFullScreen = (PlayerPrefs.GetInt("StoredFullscreen")) == 0;
            //     Debug.Log(PlayerPrefs.GetInt("StoredFullscreen"));
            //     Screen.fullScreen = isFullScreen;
            //     if (fullscreenToggle != null)
            //     {
            //         fullscreenToggle.isOn = isFullScreen;
            //     }
            bool isFullScreen = PlayerPrefs.GetInt("StoredFullscreen") == 1;
            Screen.fullScreen = isFullScreen;
            if (fullscreenToggle != null)
            {
                fullscreenToggle.isOn = isFullScreen;
            }
        }
        // else
        // {
        //     // Default to fullscreen if no saved preference
        //     Screen.fullScreen = true;
        //     if (fullscreenToggle != null)
        //     {
        //         fullscreenToggle.isOn = true;
        //     }
        // }
    }

    public void SetVolume(float volume)
    {
        float dB = Mathf.Log10(volume) * 20;
        if (volume <= 0) dB = -80;

        audioMixer.SetFloat("volume", dB);
        PlayerPrefs.SetFloat("StoredVolume", dB); // Save the new volume level
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("StoredQuality", qualityIndex); // Save the new quality level
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        PlayerPrefs.SetInt("StoredFullscreen", isFullScreen ? 1 : 0); // Save the fullscreen state
    }
}