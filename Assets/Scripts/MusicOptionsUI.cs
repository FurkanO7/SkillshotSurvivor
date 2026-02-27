using UnityEngine;
using UnityEngine.UI;

public class MusicOptionsUI : MonoBehaviour
{
    public GameObject optionsPanel; 
    public Slider volumeSlider;     
    public Toggle muteToggle;       
    public AudioSource musicSource;

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        int savedMute = PlayerPrefs.GetInt("MusicMute", 0);

        if (musicSource != null)
        {
            musicSource.volume = savedVolume;
            musicSource.mute = savedMute == 1;
        }
        if (volumeSlider != null)
            volumeSlider.value = savedVolume;
        if (muteToggle != null)
            muteToggle.isOn = savedMute == 1;

        optionsPanel.SetActive(false);
    }


    public void OnVolumeChanged(float value)
    {
        if (musicSource != null)
        {
            musicSource.volume = value;
            PlayerPrefs.SetFloat("MusicVolume", value);
            PlayerPrefs.Save();
        }
    }

    public void OnMuteChanged(bool isMuted)
    {
        if (musicSource != null)
        {
            musicSource.mute = isMuted;
            PlayerPrefs.SetInt("MusicMute", isMuted ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
}
