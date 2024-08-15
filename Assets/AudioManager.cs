using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    void Start()
    {
        float volume = PlayerPrefs.GetFloat("GameVolume", 0.75f); 
        audioMixer.SetFloat("volume", volume);
    }
}