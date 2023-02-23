using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CordSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject partPrefab, parentObject;

    [SerializeField]
    [Range(1,1000)]
    int length = 1;

    [SerializeField]
    float partDistance = 0.21f;

    [SerializeField]
    bool reset, spawn, keyboardCord, mouseCord;

    // Update is called once per frame
    void Update()
    {
        if(reset)
        {
            foreach(GameObject tmp in GameObject.FindGameObjectsWithTag("Cord"))
            {
                Destroy(tmp);
            }
            reset = false;
        }   

        if(spawn)
        {
            SpawnCord();

            spawn = false;
        }
    }

    public void SpawnCord()
    {
        int count = (int)(length/partDistance);

        for(int x=0;x<count;x++)
        {
            GameObject tmp;

            tmp = Instantiate(partPrefab, new Vector3(transform.position.x, transform.position.y * partDistance * (x+1), transform.position.z), Quaternion.identity, parentObject.transform);

            tmp.name = parentObject.transform.childCount.ToString();

            if(x==0 && mouseCord)
            {
                GameObject mouse = FindObjectOfType<MouseController>().gameObject;
                tmp.GetComponent<CharacterJoint>().connectedBody = mouse.GetComponent<Rigidbody>();
            }
            else if(x==0 && keyboardCord)
            {
                GameObject keyboard = GameObject.Find("Keyboard");
                tmp.GetComponent<CharacterJoint>().connectedBody = keyboard.GetComponent<Rigidbody>();
            }
            else
            {
                tmp.GetComponent<CharacterJoint>().connectedBody = parentObject.transform.Find((parentObject.transform.childCount-1).ToString()).GetComponent<Rigidbody>();
                tmp.transform.eulerAngles = new Vector3(100,0,0);
            }
            if(x==(count-1))
            {
                GameObject computer = GameObject.Find("Computer");
                tmp.GetComponent<CharacterJoint>().connectedBody = computer.GetComponent<Rigidbody>();
            }
        }
    }
}
