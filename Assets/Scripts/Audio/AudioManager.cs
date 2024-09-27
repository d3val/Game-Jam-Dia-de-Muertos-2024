using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider sliderAudioMaster;
    [SerializeField] private Slider sliderAudioSFX;
    [SerializeField] private Slider sliderAudioMusic;

    [SerializeField] private string mixerNameMasterVolume;
    [SerializeField] private string mixerNameSFXVolume;
    [SerializeField] private string mixerNameMusicVolume;

    private void Start()
    {
        if (PlayerPrefs.HasKey(mixerNameMasterVolume))
        {
            LoadMasterVolume();
        }
        else
        {
            SetMasterVolume();
        }

        if (PlayerPrefs.HasKey(mixerNameSFXVolume))
        {
            LoadSFXVolume();
        }
        else
        {
            SetSFXVolume();
        }

        if (PlayerPrefs.HasKey(mixerNameMusicVolume))
        {
            LoadMusicVolume();
        }
        else
        {
            SetMusicVolume();
        }
    }

    public void SetMasterVolume()
    {
        float volume = sliderAudioMaster.value;
        audioMixer.SetFloat(mixerNameMasterVolume, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(mixerNameMasterVolume, volume);
    }

    public void SetSFXVolume()
    {
        float volume = sliderAudioSFX.value;
        audioMixer.SetFloat(mixerNameSFXVolume, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(mixerNameSFXVolume, volume);
    }
    public void SetMusicVolume()
    {
        float volume = sliderAudioMusic.value;
        audioMixer.SetFloat(mixerNameMusicVolume, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(mixerNameMusicVolume, volume);
    }

    private void LoadMasterVolume()
    {
        sliderAudioMaster.value = PlayerPrefs.GetFloat(mixerNameMasterVolume);
        SetMasterVolume();
    }

    private void LoadSFXVolume()
    {
        sliderAudioMaster.value = PlayerPrefs.GetFloat(mixerNameSFXVolume);
        SetSFXVolume();
    }

    private void LoadMusicVolume()
    {
        sliderAudioMaster.value = PlayerPrefs.GetFloat(mixerNameMusicVolume);
        SetMusicVolume();
    }
}
