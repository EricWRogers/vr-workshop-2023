using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public void OnParticleCollision(GameObject other)
    {
        Debug.Log("coliding");
    }
}
