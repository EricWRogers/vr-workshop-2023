using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery_Dest : MonoBehaviour
{
    private Delivery_Task delivered;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Delivery"))
        {
            GetComponent<Collider>().enabled=false;
            delivered.DeliveryTask();
        }
    }
}
