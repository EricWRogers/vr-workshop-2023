using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Holds the different tiers that a hallucination could be with low at the smallest event and high at the biggest event
/// </summary>
public enum Tier { Low, Medium, High }

public class Event : MonoBehaviour
{
    public string eventName;
    public Tier eventTier;

    //We use a static bool here because we may need to know if ANY event is active not just this one particularly
    [HideInInspector]
    public static bool isActive = false;
    [HideInInspector]
    public UnityEvent eventStarted = new UnityEvent();
    [HideInInspector]
    public UnityEvent eventEnded = new UnityEvent();

    protected void StartEvent()
    {
        eventStarted.Invoke();
        isActive = true;
    }

    public virtual void PerformEvent()
    {
        StartEvent();
    }

    protected void FinishEvent()
    {
        eventEnded.Invoke();
        isActive = false;
    }
}
