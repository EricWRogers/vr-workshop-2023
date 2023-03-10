using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Holds the different tiers that a hallucination could be with low at the smallest event and high at the biggest event
/// </summary>
public enum Tier { Low, Medium, High }

public class HallucinationEvent : MonoBehaviour
{
    public string hallucinationName;
    [Tooltip("Ranges from Low to High. Low is the least severe hallucination whereas High is the most.")]
    public Tier hallucinationTier;
    [Tooltip("Set this to true if your code in PerformEvent needs to be called in Update.")]
    public bool needsUpdate = false;
    public GameObject globalVol;

    //We use a static bool here because we may need to know if ANY event is active not just this one particularly
    [HideInInspector]
    public static bool isActive = false;
    [HideInInspector]
    public UnityEvent hallucinationStarted = new UnityEvent();
    [HideInInspector]
    public UnityEvent hallucinationEnded = new UnityEvent();
    private bool hasStarted = false;

    public void StartHallucinationEvent()
    {
        hallucinationStarted.Invoke();
        vTurnOn();
        isActive = true;
        hasStarted = true;
    }

    public virtual void PerformHallucinationEvent()
    {
        if (!hasStarted)
            StartHallucinationEvent();
    }

    public void FinishHallucinationEvent()
    {
        hallucinationEnded.Invoke();
        vTurnOff();
        isActive = false;
    }

    private void vTurnOn()
    {
        globalVol.SetActive(true);
    }

    private void vTurnOff() 
    {
        globalVol.SetActive(false);
    }
}
