using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class VolumeControls : MonoBehaviour
{
    public AudioMixer mixer;
    public string group;

    public void SetVolume(float sliderValue)
    {
        mixer.SetFloat(group, Mathf.Log10(sliderValue)*20);
    }
}
