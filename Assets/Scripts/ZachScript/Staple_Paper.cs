using UnityEngine;
using UnityEngine.Events;

public class Staple_Paper : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stapler"))
        {
            other.GetComponent<Stapler>().Staple_Task();
            Debug.Log("Stapler is working");
        }
    }
}
