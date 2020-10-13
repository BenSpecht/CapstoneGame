using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElephantManager : MonoBehaviour
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
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            // Add elephant to book
            gameManager.AddElephantToBook();
            // Give key
            gameManager.bools.InventoryBools.hasKey = true;
        }
    }
}
