using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairRotation : MonoBehaviour
{
    Rigidbody chairRigidBody;

    public void Start()
    {
        chairRigidBody = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        chairRigidBody.angularVelocity = new Vector3(0, chairRigidBody.angularVelocity.y, 0);
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));

    }
}
