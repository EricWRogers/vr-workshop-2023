using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatHallucinationEvent : HallucinationEvent
{
    public GameObject Item;
    public float FloatTime = 10.0f;
    //private float xAngle, yAngle, zAngle;
    public Rigidbody rigidbody;

    public bool ZeroGravity = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        FloatTime = 10.0f;
    }

    

    public override void PerformHallucinationEvent()
    {
        Debug.Log("Hallucination triggered");
        if (FloatTime >= 10)
        {
            base.PerformHallucinationEvent();

            rigidbody.useGravity = false;

            Item.transform.position = new Vector3(transform.position.x, 3, transform.position.z);

            //FloatTime -= Time.deltaTime;
        }
        
        
         /*rigidbody.useGravity = false;

         Item.transform.position = new Vector3(transform.position.x, 3, transform.position.z);*/

         FloatTime -= Time.deltaTime;
         //FinishHallucinationEvent();
        if (FloatTime <= 0)
        {
            
            rigidbody.useGravity = true;
            Debug.Log("finished");
            FinishHallucinationEvent();
        }

        

        
    }
}