using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;

public class TvScreenScript : MonoBehaviour
{
    public GameObject tvScreen;

    public Material[] slides;

    public Timer timer;

    public int counter;

    public Transform attachpoint;

    public void slideshow()
    {
        if (counter == slides.Length)
        {
            counter = 0;
        }

        tvScreen.GetComponent<MeshRenderer>().material = slides[counter];
        counter++;
    }

    private void OnCollisionEnter(Collision tvScreen)
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {

        timer = GetComponentInChildren<Timer>();

        timer.TimeOut.AddListener(slideshow);

    }

    // Update is called once per frame
    void Update()
    {
    }
    
}