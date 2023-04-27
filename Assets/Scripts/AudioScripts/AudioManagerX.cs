using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManagerX : MonoBehaviour
{
    public static AudioManagerX Instance;
    public Sound[] sounds;


    // Start is called before the first frame update
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            //s.source.name = s.name;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.output;
        }
        
    }

    // Update is called once per frame
    public void play(String name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s==null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Play();
        Debug.Log(name + " Played");
    }

    public void stop(String name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s==null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Stop();
    }    


    public void toggle(String name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s==null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        if (s.source.isPlaying)
        {
            s.source.Stop();
        }
        else
        {
            s.source.Play();
        }
    }


    void Start()
    {
        play("BGM");
    }

    public void Ambiance()
    {
        int rand = UnityEngine.Random.Range(0, 12);

        sounds[rand].source.Play();
        Debug.Log("Ambiance: " + sounds[rand].name);
    }
}
