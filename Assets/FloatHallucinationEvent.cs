using UnityEngine;

public class FloatHallucinationEvent : HallucinationEvent
{
    public GameObject Item;
    public float FloatTime = 10.0f;
    //private float xAngle, yAngle, zAngle;
    public Rigidbody rigidbody;

    public bool ZeroGravity = false;

    public float Force = 0.01f;



    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        FloatTime = 10.0f;


    }

    private void Update()
    {
        //Mathf.Clamp(transform.position.y, 0f, 4f);

        if (transform.position.y >= 5f)
        {
            rigidbody.velocity = new Vector3(0f, 0f, 0f);
        }
            Debug.Log(transform.position.y);
    }

    public override void PerformHallucinationEvent()
    {


        Debug.Log("Hallucination triggered");
        if (FloatTime >= 10)
        {
            base.PerformHallucinationEvent();

            rigidbody.useGravity = false;


            Debug.Log("Running");
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, Force, rigidbody.velocity.z);



            //Item.transform.position = new Vector3(transform.position.x, transform.position.y + 3*Time.deltaTime, transform.position.z);

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