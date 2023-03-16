using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualSubjectLineInput : VirtualTextInput
{
    public VirtualTextInput contentSection;

    protected override void Finish()
    {
        base.Finish();

        contentSection.isActive = true;
    }
}
