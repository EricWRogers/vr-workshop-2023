using UnityEngine;
using UnityEngine.Events;

public class PhysicsButton : MonoBehaviour
{
    public UnityEvent onPressed = new UnityEvent();
    public UnityEvent onReleased = new UnityEvent();

    public float threshold = .1f;
    public float deadZone = .025f;

    protected bool isPressed = false;
    Vector3 startPos;
    private ConfigurableJoint joint;

    private void Start()
    {
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
    }

    protected virtual void Update()
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

    protected virtual void Pressed()
    {
        Debug.Log("press");
        isPressed = true;
        onPressed.Invoke();
    }
    
    protected virtual void Released()
    {
        isPressed = false;
        onReleased.Invoke();
    }
}
