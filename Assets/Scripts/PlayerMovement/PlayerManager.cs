using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public GameManager gameManager;
    public GameObject octopusBox;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && gameManager.bools.InventoryBools.hasOctopusBox)
        {
            // Drop box in front of player
            
            octopusBox.SetActive(true);
            
            var position = gameObject.transform.position;
            octopusBox.transform.position = position;

            gameManager.bools.InventoryBools.hasOctopusBox = false;
        } 
    }
}
