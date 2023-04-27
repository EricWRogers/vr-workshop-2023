using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidConsumed : MonoBehaviour
{
    public float energyReFill;
    
    public void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particle HIT");
        
        if(other.gameObject.CompareTag("CoffeeDrip"))
        {
            Debug.Log("Compare Tag hit");
            EnergyManager.instance.AddPoints(energyReFill);
        }
            
    }
}