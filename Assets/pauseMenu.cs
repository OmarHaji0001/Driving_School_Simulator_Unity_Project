using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public AudioMixer audioMixer;
    public int isFullScreen2;

    private float transfer;

    void Start()
    {
        Time.timeScale = 1f;
        LoadSettings();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void LoadSettings()
    {
        if (PlayerPrefs.HasKey("StoredVolume"))
        {
            transfer = PlayerPrefs.GetFloat("StoredVolume");
            audioMixer.SetFloat("volume", transfer);
        }

        if (PlayerPrefs.HasKey("StoredQuality"))
        {
            int qualityIndex = PlayerPrefs.GetInt("StoredQuality");
            QualitySettings.SetQualityLevel(qualityIndex);
        }

        if (PlayerPrefs.HasKey("StoredFullscreen"))
        {
            isFullScreen2 = PlayerPrefs.GetInt("StoredFullscreen");
            bool isFullScreen = PlayerPrefs.GetInt("StoredFullscreen") == 1;
            Screen.fullScreen = isFullScreen;

        }
    }

    public void TogglePause()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        if (PlayerPrefs.HasKey("StoredVolume"))
        {
            transfer = PlayerPrefs.GetFloat("StoredVolume");
        }
        audioMixer.SetFloat("volume", transfer);
    }

    public void LoadMenu()
    {
        PlayerPrefs.SetFloat("StoredVolume", transfer);
        PlayerPrefs.SetInt("StoredQuality", QualitySettings.GetQualityLevel());
        PlayerPrefs.SetInt("StoredFullscreen", isFullScreen2);
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        audioMixer.GetFloat("volume", out transfer);
        audioMixer.SetFloat("volume", -80);
    }

    public static bool IsGamePaused()
    {
        return GameIsPaused;
    }
}