using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CordDraw : MonoBehaviour
{
    [SerializeField]
    private Transform[] points;
    [SerializeField]
    private CordControl cord;

    // Start is called before the first frame update
    void Start()
    {
        cord.SetUpLine(points);
    }

    // Update is called once per frame
    void Update () 
    {
    }
}
