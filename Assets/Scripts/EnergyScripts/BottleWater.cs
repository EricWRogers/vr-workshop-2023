using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class waterBottleEvent : UnityEvent<float> {}

public class BottleWater : MonoBehaviour
{
    //public energyBar waterBar;
    public waterBottleEvent onDrink = new waterBottleEvent();
    public float bottleAmount; 
    
    public void OnMouseDown()
    {
        //waterBar.slider.value = 1f;
        onDrink.Invoke(bottleAmount);
        Debug.Log("Drunk some water");
    }
}
