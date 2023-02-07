using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices.ComTypes;

public class CoffeeCup : MonoBehaviour
{
    public float coffeeDrinkTime;
    public float CoffeeAmount = 0f;
    public bool FillingCoffee = false;
    public bool CupIsEmpty = true;
    public Rigidbody rigidbody;
    public GameObject Coffee;

   
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
            if(CoffeeAmount == 100f)
            {
                Debug.Log("Cup is full");
            }
            else 
            {
                CoffeeAmount /*+*/= /*Time.deltaTime * coffeeDrinkTime*/100f;
                CupIsEmpty = false;
                Debug.Log("Refilling Coffee");
                Coffee.SetActive(true);
            }
           
            

        }
        
        if (collision.CompareTag("Player"))
        {
            if (CupIsEmpty == false)
            {
                CoffeeAmount /*-*/= /*Time.deltaTime * coffeeDrinkTime*/0f;
                Debug.Log("Drinking Coffee");
                if (CoffeeAmount == 0f)
                {
                    CupIsEmpty = true;
                    Coffee.SetActive(false);
                }
            }
            
        }
    }
}
