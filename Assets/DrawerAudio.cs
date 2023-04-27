using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerAudio : MonoBehaviour
{

    AudioManagerX AMX;
    float lastInterval;

    private void Start()
    {
        AMX = AudioManagerX.Instance;
    }
    // Update is called once per frame
    void Update()
    {
        /*
        lastInterval = transform.position.z;
        if (transform.position.z >= lastInterval)
        {
            AMX.play("Open File Cabinet");
            lastInterval = transform.position.z;
        }

        if (transform.position.z <= lastInterval)
        {
            AMX.play("Metal Thud");
            lastInterval = transform.position.z;
        }
        */
    }
}
