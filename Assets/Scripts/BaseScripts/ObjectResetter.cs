using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectResetter : MonoBehaviour
{

    public Transform destinationPos;

    [Tooltip("Input the maximum distance in the scene the object can go. When it hits that position, it will teleport back to the destinationPos")]
    public float yBound, xBound, ZBound;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > xBound || transform.position.x < -xBound || transform.position.y > yBound || transform.position.y < -yBound || transform.position.z > ZBound || transform.position.z < -ZBound)
        {
            gameObject.transform.position = destinationPos.position;
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f); //Setting the velocity to zero incase it tried to become a particle accelerator. 
        }
    }
}

