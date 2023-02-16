using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    private int defaultMask;
    private int highlightMask;
    public GameObject interactableObject;

    void Awake()
    {
        defaultMask = interactableObject.layer;
        highlightMask = LayerMask.NameToLayer("Highlight");
    }

    public void HighlightObject()
    {
        interactableObject.layer = highlightMask;
        Debug.Log("HighLight");
    }

    public void DehighlightObject()
    {
        interactableObject.layer = defaultMask;
        Debug.Log("DeHighLight");
    }
}
