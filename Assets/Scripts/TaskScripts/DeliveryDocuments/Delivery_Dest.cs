using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery_Dest : MonoBehaviour
{
    private Delivery_Task task;

    private void Start()
    {
        task = FindObjectOfType<Delivery_Task>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Delivery"))
        {
            other.GetComponent<Collider>().enabled = false;
            task.DeliveryTask();
        }
    }
}
