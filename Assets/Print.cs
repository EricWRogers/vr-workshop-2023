using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Print : MonoBehaviour
{
    public Printer print;
    public Rigidbody rigidbody;
    public GameObject Document;

    private void OnTriggerEnter(Collider collision)
    {
       

        if (GameObject.Find("Document").GetComponent<Printer>().ReadyToCopy)
        {
            if (collision.gameObject.tag == "Player")
            {
                Instantiate(Document, new Vector3(0, 0, 0), Quaternion.identity);
                Debug.Log("Making Copies");
            }
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
