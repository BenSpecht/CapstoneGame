﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public GameManager gameManager;
    public GameObject octopusBox;
    public GameObject snailBunny;

    public GameObject carryJar;
    public GameObject carryBerries;
    public GameObject dropIcon;

    public GameObject snailBunnyFoodGround;
    
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
            carryJar.SetActive(false);
            dropIcon.SetActive(false);
            octopusBox.SetActive(true);
            
            var position = gameObject.transform.position;
            octopusBox.transform.position = position;

            gameManager.bools.InventoryBools.hasOctopusBox = false;
        }

        if (Input.GetKeyDown(KeyCode.R) && gameManager.bools.FoodBools.snailbunnyFood)
        {
            snailBunnyFoodGround.SetActive(true);
            carryBerries.SetActive(false);
            dropIcon.SetActive(false);

            var position = gameObject.transform.position;
            snailBunnyFoodGround.transform.position = position;

            snailBunny.GetComponent<SnailbunnyManager>().runTarget = snailBunnyFoodGround;
            gameManager.bools.FoodBools.snailBunnyComingToFood = true;

            gameManager.bools.FoodBools.snailbunnyFood = false;
        }
    }
}
