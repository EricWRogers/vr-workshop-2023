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
            GameObject keyboard, mouse, computer;
            Vector3 initial, final;

            computer = GameObject.Find("Computer");
            mouse = FindObjectOfType<MouseController>().gameObject;
            keyboard = GameObject.Find("Keyboard");

            final = computer.transform.position;
            initial = new Vector3(0,0,0);

            if(mouseCord)
            {
                initial = mouse.transform.position;
            }
            
            if(keyboardCord)
            {
                initial = keyboard.transform.position;
            }

            if(x==0)
            {
                tmp = Instantiate(partPrefab, new Vector3(initial.x, (initial.y) /* * partDistance * (x+1) */, initial.z), Quaternion.identity, parentObject.transform);
            }
            else if(x==(count-1))
            {
                tmp = Instantiate(partPrefab, new Vector3(final.x, (final.y) /* * partDistance * (x+1) */, final.z), Quaternion.identity, parentObject.transform);
            }
            else
            {
                tmp = Instantiate(partPrefab, new Vector3(((initial.x)*(1-x/count))+((final.x)*(x/count)), ((initial.y)*(1-x/count))+(final.y*(x/count)) /* * partDistance * (x+1) */, ((initial.z)*(1-x/count))+(final.z*(x/count))), Quaternion.identity, parentObject.transform);
            }

            tmp.name = parentObject.transform.childCount.ToString();

            if(x==0 && mouseCord)
            {
                tmp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                tmp.GetComponent<CharacterJoint>().connectedBody = mouse.GetComponent<Rigidbody>();
            }
            else if(x==0 && keyboardCord)
            {
                tmp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                tmp.GetComponent<CharacterJoint>().connectedBody = keyboard.GetComponent<Rigidbody>();
            }
            else
            {
                tmp.GetComponent<CharacterJoint>().connectedBody = parentObject.transform.Find((parentObject.transform.childCount-1).ToString()).GetComponent<Rigidbody>();
                tmp.transform.eulerAngles = new Vector3(100,0,0);
            }
            if(x==(count-1))
            {
                tmp.GetComponent<CharacterJoint>().connectedBody = computer.GetComponent<Rigidbody>();
            }
            parentObject.transform.Find((parentObject.transform.childCount).ToString()).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
