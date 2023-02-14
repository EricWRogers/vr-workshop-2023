using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualReplyContentInput : VirtualTextInput
{
    public GameObject sendButton;

    protected override void Finish()
    {
        base.Finish();

        sendButton.SetActive(true);
    }
}
