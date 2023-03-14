using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USBscript : MonoBehaviour
{
    public GameObject tvScreen;

    public Material[] slides;

    public void slideshow()
    {
        for (Material in slides)
        {
            tvScreen.GetComponent(Material)
        }
    }

    private void OnCollisionEnter(Collision tvScreen)
    {
        
        

    }

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
/*

var change : boolean = true;

function Start()
{
    changeTexture();
}


function changeTexture()
{

    while (change)
    {
        yield WaitForSeconds(0.5);
renderer.material.mainTexture = texture1;
yield WaitForSeconds(0.5);
renderer.material.mainTexture = texture2;
    }
}
*/