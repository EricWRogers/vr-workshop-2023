using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperShredder : Task
{
    
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
