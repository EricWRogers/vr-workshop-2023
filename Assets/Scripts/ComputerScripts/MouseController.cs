using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseController : MonoBehaviour
{
    public float speed = 10f;
    public float trackingDistance = .5f;
    public float maxSpeed = 1f;
    public LayerMask layerMask;

    private Rigidbody rb;
    private Vector3 input;
    private CursorController cursor;
    private Transform originalParent;
    private RaycastHit2D hitWindow;
    private RaycastHit2D hit;
    private GameObject originalHit;
    private bool isGrabbing = false;

    AudioManagerX AMX;

    private void Start()
    {
        AMX = AudioManagerX.Instance;
        rb = GetComponent<Rigidbody>();
        cursor = FindObjectOfType<CursorController>();
    }

    public void HandleInput(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector3>();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        AMX.play("Mouse Click");
        if (context.performed)
        {
            hit = Physics2D.Raycast(cursor.clickPoint.transform.position, Vector3.forward);

            if (hit.transform == null)
            {
                return;
            }

            Debug.Log(hit.transform.name);

            if (hit.transform.GetComponent<VirtualButton>())
            {
                hit.transform.GetComponent<VirtualButton>().onClick.Invoke();
            }

            if (hit.transform.CompareTag("Window"))
            {
                originalHit = hit.transform.gameObject; //ensures the original reference to thing we hit is not overridden
                originalParent = hit.transform.parent.parent;   //get the original parent. hit.transform is base, hit.transform.parent is window, hit.transform.parent.parent is screenspace
                hit.transform.parent.parent = cursor.transform;
                originalHit.transform.parent.SetSiblingIndex(0);    //put at the highest sibling index which is drawn last
                isGrabbing = true;
            }
        }

        if (context.canceled && isGrabbing)
        {
            originalHit.transform.parent.parent = originalParent;
            isGrabbing = false;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(input * speed * Time.deltaTime, ForceMode.Force);
        //if (rb.velocity.magnitude >= maxSpeed)
        //{
        //    rb.velocity = new Vector3(rb.velocity.normalized.x * maxSpeed, rb.velocity.normalized.y * maxSpeed, rb.velocity.normalized.z * maxSpeed);
        //}
    }

    public Vector2 GetPhysicalDirection()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.down * trackingDistance, Color.green);
        Physics.Raycast(transform.position, Vector3.down, out hit, trackingDistance, layerMask);
        if (Physics.Raycast(transform.position, Vector3.down, trackingDistance, layerMask))
            return new Vector2(rb.velocity.x, rb.velocity.z);
        else return Vector2.zero;
    }

    private void OnDrawGizmosSelected()
    {
        Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - trackingDistance, transform.position.z), Color.green);
    }
}
