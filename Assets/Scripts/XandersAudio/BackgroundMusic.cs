using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public bool playing = false;
    public GameObject manager = null;
    string song = "pixie";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnOff()
    {
        if (playing == false)
        {
            playing = true;
            AudioManager.Instance.Play(song, manager);
        }
        else
        {
            playing = false;
            AudioManager.Instance.Stop(song);
        }
    }
}
