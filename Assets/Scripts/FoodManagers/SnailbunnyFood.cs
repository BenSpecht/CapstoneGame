using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailbunnyFood : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject berrycarry;

    public GameObject dropIcon;
    
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
        Debug.Log("Berryfood");
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            dropIcon.SetActive(true);
            berrycarry.SetActive(true);
            // Pick up food
            gameObject.SetActive(false);
            gameManager.bools.FoodBools.snailbunnyFood = true;
            gameManager.DispalyBerriesFoundText();
        }
    }
}
