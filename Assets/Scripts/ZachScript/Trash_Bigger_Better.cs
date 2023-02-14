using UnityEngine;
using UnityEngine.Events;

public class Trash_Bigger_Better : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            other.GetComponent<Trash>().Trash_Task();
            Debug.Log("Taking out the trash");
        }
    }
}

