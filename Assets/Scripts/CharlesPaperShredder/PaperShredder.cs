using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperShredder : Task
{
    public int shredAmount = 5;
    public GameObject paperParticle;
    public Vector3 shredParticleLocation;
    public Quaternion shredParticleRotation;
    [HideInInspector]
    public int shredded = 0;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PaperContainer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(shredded==shredAmount)
        {
            CompleteTask(this);
        }
    }

    public IEnumerator shredPaperParticle()
    {
        GameObject shredDone = Instantiate(paperParticle, shredParticleLocation, shredParticleRotation);
        yield return new WaitForSeconds(10);
        Destroy(shredDone);
    }
}
