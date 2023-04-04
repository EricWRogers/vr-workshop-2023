using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    private Material material;
    private WaterBucket task;
    public GameObject fill;
    public float increaseSize;

    public void Start()
    {
        material = fill.GetComponent<MeshRenderer>().material;
        task = FindObjectOfType<WaterBucket>();
    }

    public void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.CompareTag("WaterDrop"))
        {
            float targetValue = material.GetFloat("_Fill") + increaseSize;

            if(targetValue > material.GetFloat("_Fill"))
            {
                material.SetFloat("_Fill", material.GetFloat("_Fill") + Time.deltaTime);
            }

        }

        if(material.GetFloat("_Fill") >= 1f)
        {
            //task complete
            task.UpdateTask();
            task.CompleteTask(task);
            task.SpawnFX(transform.position);
            Destroy(GameObject.FindGameObjectWithTag("WaterDrop"));
        }
            
    }
}
