using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    private Material material;
    public WaterBucket checker;
    public GameObject waterBucket;
    public float increaseSize;

    public void Start()
    {
        material = waterBucket.GetComponent<MeshRenderer>().material;
        checker = FindObjectOfType<WaterBucket>();
    }

    public void OnParticleCollision(GameObject other)
    {
        Debug.Log("coliding");
        if(other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("here");
            float targetValue = material.GetFloat("_Fill") + 0.1f;

            if(targetValue > material.GetFloat("_Fill"))
            {
                material.SetFloat("_Fill", material.GetFloat("_Fill") + Time.deltaTime);
            }

        }

        if(material.GetFloat("_Fill") >= 1f)
        {
            //task complete
            checker.UpdateTask();
            checker.CompleteTask(checker);
            Debug.Log("Task Complete");
        }
            
    }
}
