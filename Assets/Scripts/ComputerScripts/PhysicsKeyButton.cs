using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class KeyboardEvent : UnityEvent<string> { }

public class PhysicsKeyButton : PhysicsButton
{
    public string character;
    public KeyboardEvent onKeyDown = new KeyboardEvent();
    public KeyboardEvent onKeyUp = new KeyboardEvent();

    protected override void Pressed()
    {
        isPressed = true;
        onKeyDown.Invoke(character);
    }

    protected override void Released()
    {
        isPressed = false;
        onKeyUp.Invoke(character);
    }
}
