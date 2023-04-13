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
    }

    public void HighlightObject()
    {
        for (int i = 0; i < interactableObjects.Count; i++)
        {
            if (i == 0)
            {
                defaultMask = interactableObjects[i].layer;
            }

            interactableObjects[i].layer = highlightMask;
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
