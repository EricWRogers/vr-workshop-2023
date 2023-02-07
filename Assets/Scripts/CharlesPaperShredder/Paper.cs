using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperToShred : MonoBehaviour
{
    GameObject shredder;
    // Start is called before the first frame update
    void Awake()
    {
        shredder = GameObject.Find("PaperShredder");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
