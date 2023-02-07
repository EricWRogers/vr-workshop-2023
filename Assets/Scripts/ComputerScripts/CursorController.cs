using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public float speed = 100f;
    public float maxSpeed = 150f;
    public GameObject clickPoint;
    private MouseController mouse;
    private Rigidbody2D rb;

    private void Start()
    {
        mouse = FindObjectOfType<MouseController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(mouse.GetPhysicalDirection() * speed * Time.deltaTime);
        if (mouse.GetPhysicalDirection() == Vector2.zero)
        {
            rb.velocity = Vector2.zero;
        }

        if (rb.velocity.magnitude > 5)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed * Time.deltaTime;
        }
    }
}
