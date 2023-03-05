using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchScript : MonoBehaviour
{
    public GameObject light, switchOn, switchOff;
    public GameObject[] lights; 
    
    public bool toggle;

    /*
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (toggle == true)
                {
                    light.SetActive(true);
                    switchOn.SetActive(true);
                    switchOff.SetActive(false);
                }
                if (toggle == false)
                {
                    light.SetActive(false);
                    switchOn.SetActive(false);
                    switchOff.SetActive(true);
                }
            }
        }
    }
    */

   public void ToggleLightswitch()
    {
        Debug.Log("Switched");
        toggle = !toggle;
        if (toggle == true)
        {
            light.SetActive(true);
            switchOn.SetActive(true);
            switchOff.SetActive(false);
        }
        if (toggle == false)
        {
            light.SetActive(false);
            switchOn.SetActive(false);
            switchOff.SetActive(true);
        }

        /*
        for (light in lights)
        {
            
        }
        */
    }
    
    /*
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            //intIcon.SetActive(false);
        }
    }
    */
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
