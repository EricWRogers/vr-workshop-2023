using System.Collections;
using UnityEngine;

public class PaperShredder : MonoBehaviour
{
    public GameObject paperParticle;
    public Vector3 shredParticleLocation;
    public Quaternion shredParticleRotation;
    [HideInInspector]
    AudioManagerX AMX;
    private ShredPaperTask task;

    void Start()
    {
        task = FindObjectOfType<ShredPaperTask>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paper"))
        {
            task.UpdateTask();
            //StartCoroutine(shredPaperParticle());
            Destroy(other.gameObject);
            AMX.play("Shredder");
        }
    }

    public IEnumerator shredPaperParticle()
    {
        GameObject shredDone = Instantiate(paperParticle, shredParticleLocation, shredParticleRotation);
        yield return new WaitForSeconds(10);
        Destroy(shredDone);
    }
}
