using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperShredder : Task
{
    public int shredAmount = 5;
    //[HideInInspector]
    public int shredded = 0;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PaperContainer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
