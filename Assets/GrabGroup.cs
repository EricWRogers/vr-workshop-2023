using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GrabGroup : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent linkEvent = new UnityEvent();
    [HideInInspector]
    public UnityEvent unlinkEvent = new UnityEvent();

    public void LinkChildren()
    {
        Debug.Log("Grabbing");
        linkEvent.Invoke();
    }

    public void UnlinkChildren()
    {
        Debug.Log("ungrabbing");
        unlinkEvent.Invoke();
    }
}
