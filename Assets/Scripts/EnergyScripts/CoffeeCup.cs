using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Runtime.InteropServices.ComTypes;

[System.Serializable]
public class coffeeEvent : UnityEvent<float> {}

public class CoffeeCup : MonoBehaviour
{
    public GameObject fill;
    public float coffeeRefilled = .5f;
    public float energyRestored = .3f;
    public float amountFromMaker = .2f;
    public float coffeeDrinkTime;
    public float CoffeeAmount = 0f;
    public bool FillingCoffee = false;
    public bool CupIsEmpty = true;
    public GameObject Coffee;
    public coffeeEvent onDrink = new coffeeEvent();
    private Material mat;

    private void Start()
    {
        mat = fill.GetComponent<MeshRenderer>().material;
    }

    private void OnTriggerEnter(Collider collision)
    {
        
        //if (collision.CompareTag("PlayerMouth"))
        //{
        //    if (CupIsEmpty == false)
        //    {
        //        if (CoffeeAmount == 0f)
        //        {
        //            CupIsEmpty = true;
        //            Coffee.SetActive(false);
        //        }
        //        else
        //        {
        //            CoffeeAmount /*-*/-= /*Time.deltaTime * coffeeDrinkTime*/0.25f;
        //            Debug.Log("Drinking Coffee");
        //            onDrink.Invoke(energyRestored);
        //        }
               
        //    }
            
        //}
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("CoffeeMakerDrip"))
        {
            FindObjectOfType<CoffeeDrinking>().fillLevel += coffeeRefilled;
        }
    }
}
