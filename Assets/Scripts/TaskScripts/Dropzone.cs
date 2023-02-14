using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropzone : MonoBehaviour
{
    public int currentPinNumber=0;
    private PinTask PinTask;
    void Start()
    {
        PinTask = FindObjectOfType<PinTask>();
    }

    private void OnTriggerEnter(Collider other){
        if(!other.CompareTag("Pin"))
            return;
        currentPinNumber ++;
        PinTask.UpdateTask();

        if(currentPinNumber>=5)
            PinTask.CompleteTask(PinTask);
    }
    private void OnTriggerExit(Collider other){
        if(!other.CompareTag("Pin"))
            return;
        currentPinNumber--;
        PinTask.UpdateTask();
    }
}
