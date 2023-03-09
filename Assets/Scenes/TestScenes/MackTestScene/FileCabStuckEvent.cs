using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileCabStuckEvent : MonoBehaviour
{
    public Rigidbody playerRigi;
    bool open = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("player"))
        {
            if(other.GetComponent<Rigidbody>().velocity.magnitude <= 10)
            {
                open = true;
            }
        }
    }
}
