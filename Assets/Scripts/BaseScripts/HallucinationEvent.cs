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
    private GameObject globalVol;

    //We use a static bool here because we may need to know if ANY event is active not just this one particularly
    [HideInInspector]
    public static bool isActive = false;
    [HideInInspector]
    public UnityEvent hallucinationStarted = new UnityEvent();
    [HideInInspector]
    public UnityEvent hallucinationEnded = new UnityEvent();
    private bool hasStarted = false;

    private void Start()
    {
        globalVol = GameObject.FindGameObjectWithTag("GlobalVolume");
    }

    public void StartHallucinationEvent()
    {
        hallucinationStarted.Invoke();
        VignetteTurnOn();
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
        isActive = false;
    }

    private void VignetteTurnOn()
    {
        if (!globalVol)
        {
            Debug.LogError("Missing asset in scene, location: Assets/Prefabs/PostProcessing/vignetteGlobalVolume");
        }
        else
        {
            globalVol.SetActive(true);

            if(hallucinationTier == Tier.Low)
            {
                globalVol.GetComponent<Animator>().Play("vignetteLowPulse", 0, 0);
            }
            else if(hallucinationTier == Tier.Medium)
            {
                globalVol.GetComponent<Animator>().Play("vignetteMidPulse", 0, 0);
            }
            else if(hallucinationTier == Tier.High)
            {
                globalVol.GetComponent<Animator>().Play("vignetteHighPulse", 0, 0);
            }
            else
            {
                globalVol.GetComponent<Animator>().Play("vignetteNone", 0, 0);
                Debug.LogError("Something is wrong with Tier Enum");
            }
        }
    }
}
