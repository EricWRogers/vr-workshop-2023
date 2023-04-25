using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostVignette : MonoBehaviour
{
    public void VignetteTurnOff()
    {
        GameObject.FindGameObjectWithTag("GlobalVolume").GetComponent<Animator>().Play("vignetteNone", 0, 0);
    }
}
