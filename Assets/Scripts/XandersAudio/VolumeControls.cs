using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class VolumeControls : MonoBehaviour
{
    public Slider slider;
    public AudioMixer mixer;
    public List<AudioMixerGroup> groups;

    public void SetVolume(Slider slider, List<AudioMixerGroup> groups)
    {
        //groups[0].volume = slider.value;
    }
}
