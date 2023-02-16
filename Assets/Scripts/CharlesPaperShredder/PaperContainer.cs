using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperContainer : MonoBehaviour
{
    public GameObject paper;
    public Vector3 location;
    public Quaternion rotate;
    ShredPaperTask task;

    // Start is called before the first frame update
    void Awake()
    {
        task = FindObjectOfType<ShredPaperTask>();
        CreatePaper();
    }

    // Used to create the paper for the paper shredder task.
    void CreatePaper()
    {
        int amountOfPaper = FindObjectOfType<Staple_Task>().requiredAmount + task.requiredAmount;
        amountOfPaper += 2; //buffer
        for(int i = 1; i <= amountOfPaper; i++)
        {
            Instantiate(paper, transform.position + new Vector3(0f,0.075f*(i),0f), rotate);
        }
    }
}
