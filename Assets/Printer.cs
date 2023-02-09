using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Printer : MonoBehaviour
{
    public bool ReadyToPrint = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Document")
        {
            ReadyToPrint = true;
        }

        if (collision.gameObject.tag == "Player")
        {

        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Document")
        {
            ReadyToPrint = false;
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
