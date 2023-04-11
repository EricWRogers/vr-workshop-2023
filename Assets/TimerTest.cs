using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OmnicatLabs.Managers;

public class TimerTest : MonoBehaviour
{
    private void Start()
    {
        TimerManager.Instance.CreateTimer(5f, First);
        TimerManager.Instance.CreateTimer(5f, Second);
        //StartCoroutine(Delay());
    }

    public void First()
    {
        Debug.Log("First");
    }

    public void Second()
    {
        Debug.Log("Second");
    }

    System.Collections.IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        TimerManager.Instance.CreateTimer(5f, Second);
    }


}
