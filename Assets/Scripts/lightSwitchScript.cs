using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSwitchScript : MonoBehaviour
{
    public GameObject textToDisplay; //  displays UI text
    private bool PlayerInZone; // checks if player is in trigger
    public GameObject lightOrObject; // whatever is going to be activated

    // Start is called before the first frame update
    void Start()
    {
        PlayerInZone = false;  // player not in zone
        textToDisplay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerInZone && Input.GetKeyDown(KeyCode.F)) // if in zone and presses F
        {
            lightOrObject.SetActive(!lightOrObject.activeSelf);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
    }
}
