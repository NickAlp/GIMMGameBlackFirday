using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioSource rainAudio; // Reference to the rain AudioSource
    public Slider volumeSlider;  // Reference to the UI Slider

    private void Start()
    {
        if (volumeSlider != null && rainAudio != null)
        {
            // Set the slider's value to match the AudioSource's initial volume
            volumeSlider.value = rainAudio.volume;

            // Add listener to handle changes to the slider's value
            volumeSlider.onValueChanged.AddListener(SetRainVolume);
        }
    }

    public void SetRainVolume(float volume)
    {
        if (rainAudio != null)
        {
            rainAudio.volume = volume; // Adjust the AudioSource volume based on slider value
        }
    }
}