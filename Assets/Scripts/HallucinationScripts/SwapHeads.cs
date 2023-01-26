using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapHeads : Event
{
    public GameObject originalHead;
    public GameObject newHead;

    public void test()
    {
        Debug.Log("AAAAAAAAAAAAAAAAA");
    }

    public override void PerformEvent()
    {
        base.PerformEvent();

        originalHead.SetActive(false);
        newHead.SetActive(true);

        FinishEvent();
    }
}
