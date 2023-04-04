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

        defaultMask = interactableObjects[0].layer;
        highlightMask = LayerMask.NameToLayer("Highlight");
    }

    public void HighlightObject()
    {
        foreach(GameObject obj in interactableObjects)
        {
            obj.layer = highlightMask;
        }    
    }

    public void DehighlightObject()
    {
        foreach (GameObject obj in interactableObjects)
        {
            obj.layer = defaultMask;
        }
    }
}
