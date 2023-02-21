using UnityEngine;
using UnityEngine.Events;

public class Dumpster : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            other.GetComponent<Trash>().Trash_Task();

            FindObjectOfType<Trash_Task>().SpawnFX(transform.position, Quaternion.identity);

            Debug.Log("Taking out the trash");

        }
    }
}

