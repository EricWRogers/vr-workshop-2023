using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery_Task : Task
{
   int Delivered = 0;
    public void DeliveryTask()
    {
        
        Delivered++;
        if (Delivered >= requiredAmount)
        {
            CompleteTask(this);
        }
    }

}
