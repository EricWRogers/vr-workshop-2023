using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.XR.Interaction.Toolkit;

public class Stapler : MonoBehaviour
{
    public Transform staplePoint;
    public GameObject staple;
    public float requiredDistance = .2f;
    private Staple_Task task;
    private List<Collider> colliders = new List<Collider>();
    private bool isFinished = true;


    private void Start()
    {
        task = FindObjectOfType<Staple_Task>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paper"))
        {
            if (!colliders.Contains(other))
            {
                colliders.Add(other);
            }

            RaycastHit hit;
            Physics.Raycast(staplePoint.position, Vector3.down, out hit, requiredDistance);

            if (hit.transform != null)
            {
                if (hit.transform.CompareTag("Paper") && isFinished)
                {
                    isFinished = false;
                    Collider newParent = colliders.Last();
                    colliders.Remove(colliders.Last());

                    foreach (Collider col in colliders)
                    {
                        HingeJoint hinge = col.gameObject.AddComponent<HingeJoint>();
                        hinge.connectedBody = newParent.GetComponent<Rigidbody>();
                        hinge.axis = new Vector3(0f, 1f, 0f);
                        hinge.anchor = hit.transform.InverseTransformPoint(hit.point);

                        //Instantiate(staple, hit.transform.InverseTransformPoint(hit.point), Quaternion.identity, newParent.transform);

                        //col.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
                        Destroy(col.gameObject.GetComponent<XRGrabInteractable>());
                        //col.enabled = false;
                        col.gameObject.layer = LayerMask.NameToLayer("StapledPaper");

                        task.UpdateTask();
                    }
                    isFinished = true;
                }
            }
        }
    }
}
