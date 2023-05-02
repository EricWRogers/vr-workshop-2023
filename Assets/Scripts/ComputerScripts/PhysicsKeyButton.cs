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
    //public float heightMax = 1f;
    //public float heightMin = 1f;

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

    protected override void Update()
    {
        base.Update();

        //transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(transform.localPosition.y, heightMin, heightMax), transform.localPosition.z);
    }
}
