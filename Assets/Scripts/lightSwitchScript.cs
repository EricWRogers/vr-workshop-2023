using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSwitchScript : MonoBehaviour
{
    public GameObject lightOn, lightOff, switchOn, switchOff;//, intIcon;
    public bool toggle;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            //intIcon.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (toggle == true)
                {
                    lightOn.SetActive(true);
                    lightOff.SetActive(false);
                    switchOn.SetActive(true);
                    switchOff.SetActive(false);
                }
                if (toggle == false)
                {
                    lightOn.SetActive(false);
                    lightOff.SetActive(true);
                    switchOn.SetActive(false);
                    switchOff.SetActive(true);
                }
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            //intIcon.SetActive(false);
        }
    }
}