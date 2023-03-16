using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;

public class USBint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("screen"))
        {
            gameObject.transform.SetParent(other.transform);
            other.GetComponentInChildren<Timer>().StartTimer(4, true);
            gameObject.transform.position = other.GetComponentInChildren<TvScreenScript>().attachpoint.transform.position;

        }

    }
}
