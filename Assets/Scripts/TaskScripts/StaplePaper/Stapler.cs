using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.XR.Interaction.Toolkit;

public class Stapler : MonoBehaviour
{
    public Transform staplePoint;
    public float stapleRadius;
    public GameObject staple;
    public float requiredDistance = .2f;
    private Staple_Task task;
    private List<Collider> colliders = new List<Collider>();
    private bool isFinished = true;
    private Collider[] results;
    private bool checkForPaper = false;
    private int amountFound = 0;
    private List<Collider> stapledPapers = new List<Collider>();
    private int checkCount = 0;


    private void Start()
    {
        task = FindObjectOfType<Staple_Task>();
    }

    private void Update()
    {
        colliders.Clear();
        if (checkForPaper)
        {
            results = Physics.OverlapSphere(staplePoint.position, stapleRadius);

            foreach (var result in results)
            {
                if (stapledPapers.Contains(result))
                {
                    checkCount++;
                }
            }

            if (checkCount == stapledPapers.Count && stapledPapers.Count > 0)
            {
                checkCount = 0;
                return;
            }

            foreach (Collider result in results)
            {
                if (result.CompareTag("Paper"))
                {
                    amountFound++;
                }
            }

            if (amountFound >= 2)
            {
                foreach (Collider other in results)
                {
                    if (!colliders.Contains(other) && other.CompareTag("Paper"))
                    {
                        colliders.Add(other);
                    }
                }

                if (colliders.Count == 0)
                    return;

                RaycastHit hit;
                Physics.Raycast(staplePoint.position, Vector3.down, out hit, requiredDistance);

                if (hit.transform != null)
                {
                    if (hit.transform.CompareTag("Paper") && isFinished)
                    {
                        isFinished = false;
                        Collider newParent = colliders.Last();
                        colliders.Remove(colliders.Last());
                        stapledPapers.Clear();

                        foreach (Collider col in colliders)
                        {
                            HingeJoint hinge = col.transform.parent.gameObject.AddComponent<HingeJoint>();
                            hinge.connectedBody = newParent.transform.parent.gameObject.GetComponent<Rigidbody>();
                            hinge.axis = new Vector3(0f, 1f, 0f);
                            hinge.anchor = hit.transform.InverseTransformPoint(hit.point);

                            //Instantiate(staple, hit.transform.InverseTransformPoint(hit.point), Quaternion.identity, newParent.transform);
                            
                            foreach(Transform transform in col.transform.parent.GetComponentsInChildren<Transform>())
                            {
                                transform.gameObject.layer = LayerMask.NameToLayer("StapledPaper");
                            }
                            col.transform.parent.gameObject.name = "This One";

                            stapledPapers.Add(col);

                            task.UpdateTask();

                        }
                        colliders.Clear();
                        isFinished = true;
                    }
                }
            }
        }
    }

    public void StartChecking()
    {
        checkForPaper = true;
    }

    public void StopChecking()
    {
        checkForPaper = false;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Paper"))
    //    {
    //        if (!colliders.Contains(other))
    //        {
    //            colliders.Add(other);
    //        }

    //        RaycastHit hit;
    //        Physics.Raycast(staplePoint.position, Vector3.down, out hit, requiredDistance);

    //        if (hit.transform != null)
    //        {
    //            if (hit.transform.CompareTag("Paper") && isFinished)
    //            {
    //                isFinished = false;
    //                Collider newParent = colliders.Last();
    //                colliders.Remove(colliders.Last());

    //                foreach (Collider col in colliders)
    //                {
    //                    HingeJoint hinge = col.gameObject.AddComponent<HingeJoint>();
    //                    hinge.connectedBody = newParent.GetComponent<Rigidbody>();
    //                    hinge.axis = new Vector3(0f, 1f, 0f);
    //                    hinge.anchor = hit.transform.InverseTransformPoint(hit.point);

    //                    //Instantiate(staple, hit.transform.InverseTransformPoint(hit.point), Quaternion.identity, newParent.transform);

    //                    //col.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
    //                    Destroy(col.gameObject.GetComponent<XRGrabInteractable>());
    //                    //col.enabled = false;
    //                    col.gameObject.layer = LayerMask.NameToLayer("StapledPaper");

    //                    task.UpdateTask();
    //                    colliders.Clear();
    //                }
    //                isFinished = true;
    //            }
    //        }
    //    }
    //}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(staplePoint.position, stapleRadius);
    }
}
