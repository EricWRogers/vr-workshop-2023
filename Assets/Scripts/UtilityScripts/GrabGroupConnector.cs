using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabGroupConnector : MonoBehaviour
{
    [Tooltip("The 'parent' that this GameObject will follow. If left null it will search for a GrabGroup in the parent object.")]
    public GrabGroup groupParent;

    private FixedJoint joint;

    private void Start()
    {
        if (groupParent == null)
        {
            groupParent = GetComponentInParent<GrabGroup>();
        }

        groupParent.linkEvent.AddListener(Link);
        groupParent.unlinkEvent.AddListener(Unlink);
    }

    public void Link()
    {
        Debug.Log("Grabbed");
        if (groupParent.GetComponentInChildren<Rigidbody>() == null)
        {
            Debug.LogError("Error: Could not find RigidBody attached to Group Parent");
            return;
        }

        joint = gameObject.AddComponent<FixedJoint>();

        joint.connectedBody = groupParent.GetComponentInChildren<Rigidbody>();
    }

    public void Unlink()
    {
        Debug.Log("Ungrabbed");
        Destroy(joint);
    }
}
