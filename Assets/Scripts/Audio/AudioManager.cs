using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using System.Xml.Linq;

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
        PlayerPrefs.SetFloat(mixerNameMasterVolume, volume);
        SetVolume(mixerNameMasterVolume, volume);
    }

    public void SetSFXVolume()
    {
        float volume = sliderAudioSFX.value;
        PlayerPrefs.SetFloat(mixerNameSFXVolume, volume);
        SetVolume(mixerNameSFXVolume,volume);
    }
    public void SetMusicVolume()
    {
        float volume = sliderAudioMusic.value;
        PlayerPrefs.SetFloat(mixerNameMusicVolume, volume);
        SetVolume(mixerNameMusicVolume, volume);
    }

    private void LoadMasterVolume()
    {
        float volume = PlayerPrefs.GetFloat(mixerNameMasterVolume);
        sliderAudioMaster.SetValueWithoutNotify(volume);
        SetVolume(mixerNameMasterVolume, volume);
    }

    private void LoadSFXVolume()
    {
        float volume = PlayerPrefs.GetFloat(mixerNameSFXVolume);
        sliderAudioSFX.SetValueWithoutNotify(volume);
        SetVolume(mixerNameSFXVolume, volume);
    }

    private void LoadMusicVolume()
    {
        float volume = PlayerPrefs.GetFloat(mixerNameMusicVolume);
        sliderAudioMusic.SetValueWithoutNotify(volume);
        SetVolume(mixerNameMusicVolume, volume);
    }

    private void SetVolume(string mixName, float volume)
    {
        audioMixer.SetFloat(mixName, Mathf.Log10(volume) * 20);
    }
}
