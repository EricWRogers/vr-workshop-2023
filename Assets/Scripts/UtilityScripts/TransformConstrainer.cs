using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformConstrainer : MonoBehaviour
{
    public bool clampX;
    public bool clampY;
    public bool clampZ;

    public float max = 1f;
    public float min = 1f;

    private void Update()
    {
        if (clampX)
        {
            transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, min, max), transform.localPosition.y, transform.localPosition.z);
        }
        if (clampY)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(transform.localPosition.y, min, max), transform.localPosition.z);
        }
        if (clampZ)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, Mathf.Clamp(transform.localPosition.z, min, max));
        }
    }
}
