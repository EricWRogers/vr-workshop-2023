using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperToShred : MonoBehaviour
{
    PaperShredder shredder;

    void Awake()
    {
        shredder = FindObjectOfType<PaperShredder>();
    }
}
