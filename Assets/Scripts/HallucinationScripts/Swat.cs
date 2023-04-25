using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swat : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<StartPixie>().FinishHallucinationEvent();
            Destroy(transform.parent.gameObject);
        }
    }
}
