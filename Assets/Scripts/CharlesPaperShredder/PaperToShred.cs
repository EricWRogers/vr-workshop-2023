using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperToShred : MonoBehaviour
{
    PaperShredder shredder;
    // Start is called before the first frame update
    void Awake()
    {
        shredder = GameObject.Find("Shredder").GetComponent<PaperShredder>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Shredder"))
        {
            shredder.shredded++;
            shredder.UpdateTask();
            shredder.shredPaperParticle();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
