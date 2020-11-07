using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantarayFood : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject mantafoodcarry;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            gameManager.DisplayInteract();
        }
        Debug.Log("Mantafood");
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            mantafoodcarry.SetActive(true);
            gameManager.DisplayMantaFoodText();
            gameManager.bools.FoodBools.mantarayFood = true;
            gameObject.SetActive(false);

            FMODUnity.RuntimeManager.PlayOneShot("event:/Player/PickUp_Item", GetComponent<Transform>().position);
        }
    }
}
