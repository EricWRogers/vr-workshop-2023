using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;
using System.Linq;

public class HallucinationManager : MonoBehaviour
{
    public float highChanceAdded = 5f;
    public float mediumChanceAdded = 3f;
    public float lowChanceAdded = 1f;

    private EnergyManager energySystem;
    public List<HallucinationEvent> highEvents;
    public List<HallucinationEvent> mediumEvents;
    public List<HallucinationEvent> lowEvents;
    private Timer timer;

    private HallucinationEvent currentHallucination;
    private float chance = 0f;

    private void Start()
    {
        energySystem = FindObjectOfType<EnergyManager>();
        timer = GetComponent<Timer>();

        timer.TimeOut.AddListener(IncreaseChance);
        timer.TimeOut.AddListener(PickEvent);

        highEvents = new List<HallucinationEvent>(FindObjectsOfType<HallucinationEvent>()).Where(hallucination => hallucination.hallucinationTier == Tier.High).ToList();
        mediumEvents = new List<HallucinationEvent>(FindObjectsOfType<HallucinationEvent>()).Where(hallucination => hallucination.hallucinationTier == Tier.Medium).ToList();
        lowEvents = new List<HallucinationEvent>(FindObjectsOfType<HallucinationEvent>()).Where(hallucination => hallucination.hallucinationTier == Tier.Low).ToList();
    }

    private void IncreaseChance()
    {
        switch(energySystem.GetTier())
        {
            case Tier.High:
                chance += highChanceAdded;
                break;
            case Tier.Medium:
                chance += mediumChanceAdded;
                break;
            case Tier.Low:
                chance += lowChanceAdded;
                break;
        }
    }

    private void PickEvent()
    {
        if (!HallucinationEvent.isActive)
        {
            if (chance >= Random.Range(1f, 100f))
            {
                switch (energySystem.GetTier())
                {
                    case Tier.High:
                        currentHallucination = highEvents[Random.Range(0, highEvents.Count)];
                        DoEvent(currentHallucination);
                        break;
                    case Tier.Medium:
                        currentHallucination = mediumEvents[Random.Range(0, mediumEvents.Count)];
                        DoEvent(currentHallucination);
                        break;
                    case Tier.Low:
                        currentHallucination = lowEvents[Random.Range(0, lowEvents.Count)];
                        DoEvent(currentHallucination);
                        break;
                }

                chance = 0f;
            }
        }
    }

    private void DoEvent(HallucinationEvent _hallucination)
    {
        if (_hallucination.needsUpdate)
            return;

        _hallucination.PerformHallucinationEvent();
    }

    private void Update()
    {
        Debug.Log(HallucinationEvent.isActive);

        if (currentHallucination != null)
        {
            if (currentHallucination.needsUpdate)
                currentHallucination.PerformHallucinationEvent();
        }
    }
}
