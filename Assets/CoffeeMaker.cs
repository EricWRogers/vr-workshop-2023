using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMaker : MonoBehaviour
{
    public ParticleSystem drip;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CoffeeCup"))
        {
            drip.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CoffeCup"))
        {
            drip.Stop();
        }
    }
}
