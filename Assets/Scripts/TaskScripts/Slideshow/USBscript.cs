using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;

public class USBscript : MonoBehaviour
{
    public Animator animator;
    public string SlideShowAnim = "SlideShowAnim";
    public Rigidbody UsbRigidBody;
    Vector3 usbPos = new Vector3(0.0f, -0.25f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("TV"))
        {
            //gameObject.transform.Translate(usbPos);
            other.GetComponentInChildren<Canvas>().gameObject.SetActive(true);         
            animator.Play(SlideShowAnim,0,0.5f);

            UsbRigidBody.constraints = RigidbodyConstraints.FreezePosition;

        }
        
    }
}
