using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketHallucinationEvent : HallucinationEvent
{
    public GameObject Bucket;
    public float xAngle, yAngle, zAngle;

    public override void PerformHallucinationEvent()
    {
        base.PerformHallucinationEvent();

        Bucket.transform.Rotate(0, 0, 180, Space.Self);

        FinishHallucinationEvent();
    }
}
