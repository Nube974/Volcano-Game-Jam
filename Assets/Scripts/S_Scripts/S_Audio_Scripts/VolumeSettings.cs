using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
   [SerializeField] private AudioMixer myMixer;
   [SerializeField] private Slider musicSlider;
   [SerializeField] private Slider SFXSlider;

   private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            GetMusicVolume();
            GetSFXVolume();
        }
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        myMixer.SetFloat("sfx", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
        PlayerPrefs.Save();
    }

    private void LoadVolume()
    {
        GetMusicVolume();
        GetSFXVolume();
    }

    public void GetMusicVolume()
    {
        float loadedMusicVolume = PlayerPrefs.GetFloat("musicVolume");
        musicSlider.value = loadedMusicVolume;
    }

    public void GetSFXVolume()
    {
        float loadedSFXVolume = PlayerPrefs.GetFloat("SFXVolume");
        SFXSlider.value = loadedSFXVolume;
    }
}
