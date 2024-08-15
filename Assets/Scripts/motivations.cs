using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Collections; // Required for coroutines
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.Video; // Required for VideoPlayer
using UnityEngine.UI;
using Unity.VisualScripting; // Required for RawImage

public class DebugHiBye : MonoBehaviour
{
    private float totalElapsedTime = 0f;
    private float activeDrivingTime = 0f;
    private bool isByeTime = false;
    public GameObject motivationPanel;
    public GameObject warningPanel;

    public GameObject motMenuUI;
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer component
    public RawImage videoDisplay; // Reference to the RawImage component for displaying the video

    private TextMeshProUGUI messageText;
    private TextMeshProUGUI messageText2;

    private bool flg = false;

    // Reference to the car's Rigidbody component
    public Rigidbody carRigidbody;

    // Minimum active driving time required to pass the training
    private const float requiredActiveDrivingTime = 540f; // 6 minutes
    private const float firstMotivationTime = 180f; // 2 minutes
    private const float secondMotivationTime = 360f; // 4 minutes

    void Start()
    {
        InvokeRepeating("DebugHiOrBye", 0f, 1f); // Check every second
        if (motivationPanel != null)
        {
            // Find the TextMeshProUGUI component in the Panel
            messageText = motivationPanel.GetComponentInChildren<TextMeshProUGUI>();
            motivationPanel.SetActive(false); // Ensure the panel is hidden at start
            messageText2 = warningPanel.GetComponentInChildren<TextMeshProUGUI>();
            warningPanel.SetActive(false); // Ensure the panel is hidden at start
        }
    }

    void DebugHiOrBye()
    {
        if (flg == false)
        {
            flg = true;
            return;
        }

        totalElapsedTime += 1f;

        // Check if the car's velocity is zero
        if (carRigidbody != null && carRigidbody.velocity.magnitude > 0.1f) // Adjust the threshold as needed
        {
            activeDrivingTime += 1f;
        }

        if (strikes.counterOfStrikes == 0 && activeDrivingTime == firstMotivationTime && motivationPanel != null)
        {
            messageText.text = "Go ahead, you're doing well so far";
            motivationPanel.SetActive(true);
            StartCoroutine(HidePanelAfterDelay(3.0f)); // Delay for 3 seconds
        }
        else if (strikes.counterOfStrikes == 0 && activeDrivingTime == secondMotivationTime && motivationPanel != null)
        {
            messageText.text = "Go ahead you're almost there";
            motivationPanel.SetActive(true);
            StartCoroutine(HidePanelAfterDelay(3.0f)); // Delay for 3 seconds
        }
        else if (activeDrivingTime >= requiredActiveDrivingTime)
        {
            Debug.Log("you are done");
            CancelInvoke("DebugHiOrBye");
            if (strikes.counterOfStrikes == 0)
            {
                motMenuUI.GetComponentInChildren<TextMeshProUGUI>().SetText("You finished the training successfully without any mistake");
                if (videoPlayer != null && videoDisplay != null)
                {
                    videoDisplay.texture = videoPlayer.targetTexture; // Assign the target texture
                    videoPlayer.Play(); // Play the video
                }
            }
            else
            {
                string failMessage = "You failed the training, you have " + strikes.counterOfStrikes + " strikes";
                motMenuUI.GetComponentInChildren<TextMeshProUGUI>().SetText(failMessage);
                if (warningPanel != null)
                    warningPanel.SetActive(false);
            }
            motMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void playAgain()
    {
        motMenuUI.SetActive(false);
        Time.timeScale = 1f;
        strikes.counterOfStrikes = 0;
        strikes.strikeMsg.text = "Strikes:0";
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator HidePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        motivationPanel.SetActive(false); // Hide the panel
    }
}