using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class KeyboardEvent : UnityEvent<string> { }

public class PhysicsButton : MonoBehaviour
{
    public string character;

    public KeyboardEvent onPressed = new KeyboardEvent();
    public KeyboardEvent onReleased = new KeyboardEvent();

    public float threshold = .1f;
    public float deadZone = .025f;

    private bool isPressed = false;
    Vector3 startPos;
    private ConfigurableJoint joint;

    private void Start()
    {
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
    }

    private void Update()
    {
        if (!isPressed && GetValue() + threshold >= 1)
        {
            Pressed();
        }
        if (isPressed && GetValue() - threshold <= 0)
        {
            Released();
        }
    }

    private float GetValue()
    {
        float value = Vector3.Distance(startPos, transform.localPosition) / joint.linearLimit.limit;

        if (Mathf.Abs(value) < deadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        isPressed = true;
        onPressed.Invoke(character);
    }
    
    private void Released()
    {
        isPressed = false;
        onReleased.Invoke(character);
    }
}
