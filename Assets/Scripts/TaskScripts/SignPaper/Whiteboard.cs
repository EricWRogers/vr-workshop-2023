using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Whiteboard : MonoBehaviour
{
    [HideInInspector]
    public Texture2D texture;
    [HideInInspector]
    public Vector2 textureSize;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend.material.mainTexture == null)
            Debug.Log("Eror");
        textureSize = new Vector2(rend.material.GetTexture("_MainTex").width, rend.material.GetTexture("_MainTex").height);
        texture = new Texture2D((int)textureSize.x,(int)textureSize.y);
        rend.material.mainTexture = texture;

        Debug.Log(textureSize);
    }
}
