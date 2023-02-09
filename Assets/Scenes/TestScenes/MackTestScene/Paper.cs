using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Drawer"))
        {
            other.GetComponent<Drawer>().FilePaper();
            Destroy(gameObject);
        }
    }
}
