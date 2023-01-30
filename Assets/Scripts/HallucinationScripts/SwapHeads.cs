using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapHeads : HallucinationEvent
{
    public GameObject originalHead;
    public GameObject newHead;

    public void test()
    {
        Debug.Log("AAAAAAAAAAAAAAAAA");
    }

    public override void PerformHallucinationEvent()
    {
        base.PerformHallucinationEvent();

        originalHead.SetActive(false);
        newHead.SetActive(true);

        FinishHallucinationEvent();
    }
}
