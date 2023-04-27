using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    private int defaultMask;
    private int highlightMask;
    public List<GameObject> interactableObjects = new List<GameObject>();

    void Awake()
    {
        if (interactableObjects.Count == 0)
        {
            interactableObjects.Add(gameObject);
        }

        highlightMask = LayerMask.NameToLayer("Highlight");
        defaultMask = interactableObjects[0].layer;
    }

    public void HighlightObject()
    {
        foreach (GameObject obj in interactableObjects)
        {
            if (obj != null)
                obj.layer = highlightMask;
        }    
    }

    public void DehighlightObject()
    {
        foreach (GameObject obj in interactableObjects)
        {
            if (obj != null)
                obj.layer = defaultMask;
        }
    }
}
