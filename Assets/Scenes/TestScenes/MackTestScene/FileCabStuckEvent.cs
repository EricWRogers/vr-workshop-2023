using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileCabStuckEvent : MonoBehaviour
{
    public Rigidbody playerRigi;
    bool open = false;

    OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("player"))
        {
            if(other.GetComponent.velocity <= 10)
            {
                open = true;
            }
        }
    }
}
