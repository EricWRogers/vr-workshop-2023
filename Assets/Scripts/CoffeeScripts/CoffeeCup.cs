using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Runtime.InteropServices.ComTypes;

[System.Serializable]
public class coffeeEvent : UnityEvent<float> {}

public class CoffeeCup : MonoBehaviour
{
    public float coffeeDrinkTime;
    public float CoffeeAmount = 0f;
    public bool FillingCoffee = false;
    public bool CupIsEmpty = true;
    public Rigidbody rigidbody;
    public GameObject Coffee;
    public coffeeEvent onDrink = new coffeeEvent();

   
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("CoffeeMaker"))
        {
            if(CoffeeAmount == 1.0f)
            {
                Debug.Log("Cup is full");
            }
            else 
            {
                CoffeeAmount /*+*/= /*Time.deltaTime * coffeeDrinkTime*/1.0f;
                CupIsEmpty = false;
                Debug.Log("Refilling Coffee");
                Coffee.SetActive(true);
            }
           
            

        }
        
        if (collision.CompareTag("Player"))
        {
            if (CupIsEmpty == false)
            {
                if (CoffeeAmount == 0f)
                {
                    CupIsEmpty = true;
                    Coffee.SetActive(false);
                }
                else
                {
                    CoffeeAmount /*-*/-= /*Time.deltaTime * coffeeDrinkTime*/0.25f;
                    Debug.Log("Drinking Coffee");
                    onDrink.Invoke(CoffeeAmount);
                }
               
            }
            
        }
    }
}
