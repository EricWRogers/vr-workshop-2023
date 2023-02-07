using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperContainer : MonoBehaviour
{
    public int paperAmount;
    public GameObject paper;

    // Start is called before the first frame update
    void Start()
    {
        CreatePaper();
    }

    // Used to create the paper for the paper shredder task.
    void CreatePaper()
    {
        for(int i=1; i<=paperAmount; i++)
        {
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
