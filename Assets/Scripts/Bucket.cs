using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    private Material material;
    public GameObject waterBucket;
    public float increaseSize;

    public void Start()
    {
        material = waterBucket.GetComponent<MeshRenderer>().material;
    }

    public void OnParticleCollision(GameObject other)
    {
        Debug.Log("coliding");
        if(other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("here");
            //waterBucket.transform.LeanScaleY(waterBucket.transform.localScale.y + increaseSize, .5f).setEaseLinear();
            //material.LeanValue(material.GetFloat("_Fill"), material.GetFloat("_Fill") + increaseSize, .5f);
            //material.SetFloat("_Fill", material.GetFloat("_Fill") + increaseSize);
            LeanTween.value(material.GetFloat("_Fill"), material.GetFloat("_Fill") + increaseSize, .5f);
        }
            
    }
}
