using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunchboxTask : Task
{
    private LunchboxDropbox dropbox;

    private void Start()
    {
        dropbox = FindObjectOfType<LunchboxDropbox>();
    }
}
