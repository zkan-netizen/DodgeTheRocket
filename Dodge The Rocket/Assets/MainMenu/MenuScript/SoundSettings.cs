using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public static SoundSettings audiocaller;

    public Text VolumeAmount;

    public Slider slider;

    private void Start()
    {
        LoadAudio();
    }

    public void SetAudio(float _soundValue)
    {
        AudioListener.volume = _soundValue;
        VolumeAmount.text = ((int)(_soundValue * 100)).ToString();
        SaveAudio();
    }

    private void SaveAudio()
    {
        PlayerPrefs.SetFloat("AudioVolume", AudioListener.volume);
    }

    public void LoadAudio()
    {
        if (PlayerPrefs.HasKey("AudioVolume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("AudioVolume");
            slider.value = PlayerPrefs.GetFloat("AudioVolume");
        }
        else
        {
            PlayerPrefs.SetFloat("AudioVolume", 0.4f);
            AudioListener.volume = PlayerPrefs.GetFloat("AudioVolume");
        }
    }
}
