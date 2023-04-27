using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeDrinking : MonoBehaviour
{
    public float maxDistance = 5.0f;

    public float decreaseSize;

    private float maxValue = 1.0f;
    private float minValue = 0.0f;
    
    public GameObject origin;
    public GameObject fill;
    public GameObject topPoint;
    public GameObject bottomPoint;
    public ParticleSystem particleSystem;
    public List<Transform> Points;
    public LayerMask layerToCheck;

    private Material material;

    //public bool hasCoffee { get { return material.GetFloat("_Fill") > 0.0f; } }
    public bool isPouring;
    public float fillLevel = 1.0f;
    public float min = 0.475f;
    public float max = 0.525f;

    public void Start()
    {
        material = fill.GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        Vector3.Lerp(bottomPoint.transform.position, topPoint.transform.position, material.GetFloat("_Fill"));
        
        var emission = particleSystem.emission;
        isPouring = SpillChecker();
        emission.enabled = isPouring;

        if(isPouring)
        {
            fillLevel = Mathf.Clamp(
                fillLevel - (decreaseSize * Time.deltaTime),
                0.0f,
                1.0f
            );
            
            material.SetFloat("_Fill", (fillLevel * (max - min)) + min);
            emission.enabled = fillLevel > 0.0f;
        }
        else 
        {
            emission.enabled = false;
        }
    }

    public bool SpillChecker()
    {
            RaycastHit hit;

            particleSystem.gameObject.transform.position = Points[IndexOfLowestPointDetector()].position;

            var emission = particleSystem.emission;


            if(!Physics.Raycast(origin.transform.position, Vector3.Normalize(new Vector3(0.0f,0.0f,1.0f)), out hit, maxDistance, layerToCheck))
            {
                Debug.Log("Hit");
                return true;
            }
            if(!Physics.Raycast(origin.transform.position, Vector3.Normalize(new Vector3(1.0f,0.0f,1.0f)), out hit, maxDistance, layerToCheck))
            {
                Debug.Log("Hit");
                return true;
            }
            if(!Physics.Raycast(origin.transform.position, Vector3.Normalize(new Vector3(1.0f,0.0f,0.0f)), out hit, maxDistance, layerToCheck))
            {
                Debug.Log("Hit");
                return true;
            }
            if(!Physics.Raycast(origin.transform.position, Vector3.Normalize(new Vector3(0.0f,0.0f,-1.0f)), out hit, maxDistance, layerToCheck))
            {
                Debug.Log("Hit");
                return true;
            }
            if(!Physics.Raycast(origin.transform.position, Vector3.Normalize(new Vector3(1.0f,0.0f,-1.0f)), out hit, maxDistance, layerToCheck))
            {
                Debug.Log("Hit");
                return true;
            }
            if(!Physics.Raycast(origin.transform.position, Vector3.Normalize(new Vector3(-1.0f,0.0f,-1.0f)), out hit, maxDistance, layerToCheck))
            {
                Debug.Log("Hit");
                return true;
            }
            if(!Physics.Raycast(origin.transform.position, Vector3.Normalize(new Vector3(-1.0f,0.0f,0.0f)), out hit, maxDistance, layerToCheck))
            {
                Debug.Log("Hit");
                return true;
            }
            if(!Physics.Raycast(origin.transform.position, Vector3.Normalize(new Vector3(-1.0f,0.0f,1.0f)), out hit, maxDistance, layerToCheck))
            {
                Debug.Log("Hit");
                return true;
            }
            return false;


    }

    public int IndexOfLowestPointDetector()
    {
        int lowestIndex = 0;

        for(int i = 0; i < Points.Count; i++)
        {
            if(Points[i].position.y < Points[lowestIndex].position.y)
            {
                lowestIndex = i;
            }
        }
        return lowestIndex;
    }
}
