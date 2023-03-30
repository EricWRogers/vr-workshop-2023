using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampForm : MonoBehaviour
{
    public bool Approved = false;
    public bool Denied = false;
    public Rigidbody rigidbody;
    public GameObject ApprovedMark;
    public GameObject DeniedMark;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("ApproveStamp"))
        {
            if (Denied == false && Approved == false)
            {
                ApprovedMark.SetActive(true);
                Debug.Log("Form Approved");
            }
        }

        if (collision.CompareTag("DenyStamp"))
        {
            if (Denied == false && Approved == false)
            {
                DeniedMark.SetActive(true);
                Debug.Log("Form Approved");
            }
        }
    }
}
