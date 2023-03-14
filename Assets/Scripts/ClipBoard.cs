using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipBoard : MonoBehaviour
{
    public GameObject clipBoard;
    public Vector3 hip;
    
    public void Awake()
    {
        hip = clipBoard.transform.position;
    }
    
    public void ResetPosition()
    {
        clipBoard.transform.position = hip;

    }
}
