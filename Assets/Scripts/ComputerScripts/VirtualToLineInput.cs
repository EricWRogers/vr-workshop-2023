using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualToLineInput : VirtualTextInput
{
    public VirtualTextInput subjectLine;

    protected override void Start()
    {
        base.Start();

        isActive = true;
    }

    protected override void Finish()
    {
        base.Finish();

        subjectLine.isActive = true;
    }
}
