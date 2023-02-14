using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public MeshRenderer renderer;
    public ParticleSystem ps;
    public Material incomplete;
    public Material complete;
    public virtual void UpdatePin(){
        renderer.material = incomplete;
        ps.Play();
    }
    public virtual void CompletePin(){
        renderer.material = complete;
    }
}
