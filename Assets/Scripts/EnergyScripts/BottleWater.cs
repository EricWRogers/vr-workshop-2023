using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class waterBottleEvent : UnityEvent<float> {}

public class BottleWater : MonoBehaviour
{
    public waterBottleEvent onDrink = new waterBottleEvent();
    public float heldAmount = 1f;
    public float refillAmount;
    public Collider mainCollider;

    public void EnableCollider()
    {
        mainCollider.enabled = true;
    }

    public void DisableCollider()
    {
        mainCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerMouth") && heldAmount > 0)
        {
            onDrink.Invoke(refillAmount);
            heldAmount -= refillAmount;
            Debug.Log("Drunk some water");
        }
    }
}
