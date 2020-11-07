using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleFood : MonoBehaviour
{
    public GameManager gameManager;
    
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
        Debug.Log("Whalefood");
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            gameManager.DisplayWhaleFedText();
            gameManager.bools.FoodBools.whaleFood = true;
            gameObject.SetActive(false);

            FMODUnity.RuntimeManager.PlayOneShot("event:/Player/PickUp_Item", GetComponent<Transform>().position);
        }
    }
}
