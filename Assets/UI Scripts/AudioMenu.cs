using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMenu : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    [SerializeField] TMP_Text masterVolumeText;
    [SerializeField] TMP_Text ambienceVolumeText;
    [SerializeField] TMP_Text sfxVolumeText;

    //[SerializeField] Slider masterVolumeSlider;
    //[SerializeField] Slider ambienceVolumeSlider;
    //[SerializeField] Slider sfxVolumeSlider;

    void Start()
    {
        
    }


    public void SetMasterVolume(float volume)
    {
        volume *= 10;
        int volumeToInt = (int)Mathf.Clamp(volume, 0, 20);

        masterVolumeText.text = "Master: " + volumeToInt.ToString();

        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 10);
    }

    public void SetAmbienceVolume(float volume)
    {
        volume *= 10;
        int volumeToInt = (int)Mathf.Clamp(volume, 0, 20);

        ambienceVolumeText.text = "Ambience: " + volumeToInt.ToString();

        audioMixer.SetFloat("AmbienceVolume", Mathf.Log10(volume) * 10);
    }

    public void SetSFXVolume(float volume)
    {
        volume *= 10;
        int volumeToInt = (int)Mathf.Clamp(volume, 0, 20);

        sfxVolumeText.text = "SFX: " + volumeToInt.ToString();

        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 10);
    }
}
