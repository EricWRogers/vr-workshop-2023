using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public ParticleSystem ps;
    public Material incomplete;
    public Material complete;

    private MeshRenderer mesh;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    public virtual void UpdatePin(){
        mesh.material = incomplete;
        ps.Play();
    }
    public virtual void CompletePin(){
        mesh.material = complete;
    }
}
