using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidConsumed : MonoBehaviour
{
    public float energyReFill;
    
    public void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("CoffeeDrip"))
        {
            EnergyManager.instance.AddPoints(energyReFill);
        }
            
    }
}