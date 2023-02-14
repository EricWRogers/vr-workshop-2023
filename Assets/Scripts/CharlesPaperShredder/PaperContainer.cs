using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperContainer : MonoBehaviour
{
    public int paperAmount;
    public GameObject paper;
    public Vector3 location;
    public Quaternion rotate;
    PaperShredder shredder;

    // Start is called before the first frame update
    void Awake()
    {
        shredder = FindObjectOfType<PaperShredder>();
        paperAmount = shredder.shredAmount;
        CreatePaper();
    }

    public void startTask()
    {
        CreatePaper();
    }

    // Used to create the paper for the paper shredder task.
    void CreatePaper()
    {
        for(int i=1; i<=paperAmount; i++)
        {
            GameObject papermulti = Instantiate(paper, location+new Vector3(0f,0.075f*(i),0f), rotate);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
