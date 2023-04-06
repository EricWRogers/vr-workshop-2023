using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostVignette : MonoBehaviour
{
    public void GetVignetteTurnOff()
    {
        // real jank way of getting the turn off function to the animation event
        FindObjectOfType<HallucinationEvent>().GetComponent<HallucinationEvent>().VignetteTurnOff();
    }
}
