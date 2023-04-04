using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery_Task : Task
{
    public int Delivered = 0;
    public void DeliveryTask()
    {     
        Delivered++;
        if (Delivered >= 2)
        {
            CompleteTask(this);
        }
    }

}
