using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    private int defaultMask;
    private int highlightMask;
    public GameObject interactableObject;

    void awake()
    {
        defaultMask = LayerMask.NameToLayer("default");
        highlightMask = LayerMask.NameToLayer("Hightlight");
    }

    public void HighlightObject()
    {
        interactableObject.layer = highlightMask;
    }

    public void DehighlightObject()
    {
        interactableObject.layer = defaultMask;
    }
}
