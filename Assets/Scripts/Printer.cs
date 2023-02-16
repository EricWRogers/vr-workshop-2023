using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Printer : MonoBehaviour
{
    public bool ReadyToCopy = false;
    public Rigidbody rigidbody;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Printer")
        {
            ReadyToCopy = true;
        }

       
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Printer")
        {
            ReadyToCopy = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
