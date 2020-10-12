using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class WhaleManager : MonoBehaviour
{

    public GameManager gameManager;

    public GameObject playerCamera;
    public GameObject whaleCamera;

    public GameObject playerObject;
    public GameObject darkWorldDismount;
    public GameObject forestWorldDismount;
    public GameObject flowerDismount;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IdleWhale();
    }

    private void IdleWhale()
    {
        if (gameManager.bools.WhalePathing.whaleAtForest && !gameManager.bools.WhalePathing.whaleReadyToLeaveForest)
        {
            gameManager.bools.WhalePathing.whaleCircleForest = true;
        } else if (gameManager.bools.WhalePathing.whaleAtDark && !gameManager.bools.WhalePathing.whaleReadyToLeaveDark)
        {
            gameManager.bools.WhalePathing.whaleCircleDark = true;
        }
    }

    private void GetOnWhale()
    {
        // ride whale
        playerCamera.SetActive(false);
        whaleCamera.SetActive(true);

        gameManager.bools.ControlBools.playerControl = false;
        gameManager.bools.ControlBools.whaleControl = true;
                
        // Move player onto whale
        playerObject.transform.SetParent(gameObject.transform);
        var playerAdjust = new Vector3(-0.087f, 8.54f, 6.69f);
        playerObject.transform.position = gameObject.transform.position + playerAdjust;
        var tempRotation = gameObject.transform.rotation;
        tempRotation.y = -180;
        playerObject.transform.localRotation = tempRotation;
        playerObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

        // Disable player movement
        playerObject.GetComponent<ThirdPersonCharacter>().enabled = false;
        playerObject.GetComponent<ThirdPersonUserControl>().enabled = false;
        playerObject.GetComponent<Animator>().enabled = false;
        
        // Run whale movement
        if (gameManager.bools.WhalePathing.whaleAtTutorial)
        {
            gameManager.bools.WhalePathing.tutorialToForest = true;
            gameManager.bools.WhalePathing.whaleAtTutorial = false;
        } else if (gameManager.bools.WhalePathing.whaleAtForest)
        {
            gameManager.bools.WhalePathing.forestToDark = true;
            gameManager.bools.WhalePathing.whaleAtForest = false;
        } else if (gameManager.bools.WhalePathing.whaleAtDark)
        {
            gameManager.bools.WhalePathing.darkToFlower = true;
            gameManager.bools.WhalePathing.whaleAtDark = false;
        }
    }

    public void GetOffWhale()
    {
        whaleCamera.SetActive(false);
        playerCamera.SetActive(true);

        gameManager.bools.ControlBools.playerControl = true;
        gameManager.bools.ControlBools.whaleControl = false;
        
        // Move player off of whale
        playerObject.transform.SetParent(null);

        if (gameManager.bools.WhalePathing.whaleAtDark)
        {
            playerObject.transform.localPosition = darkWorldDismount.transform.position;
        } else if (gameManager.bools.WhalePathing.whaleAtForest)
        {
            playerObject.transform.localPosition = forestWorldDismount.transform.position;
        } else if (gameManager.bools.WhalePathing.whaleAtFlower)
        {
            playerObject.transform.localPosition = flowerDismount.transform.position;
        }
        
        playerObject.transform.rotation = Quaternion.identity;
        
        playerObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        playerObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        
        // Enable player movement
        playerObject.GetComponent<ThirdPersonCharacter>().enabled = true;
        playerObject.GetComponent<ThirdPersonUserControl>().enabled = true;
        playerObject.GetComponent<Animator>().enabled = true;

        // Disable whale movement
        if (gameManager.bools.WhalePathing.whaleAtForest)
        {
            gameManager.bools.WhalePathing.tutorialToForest = false;
        } else if (gameManager.bools.WhalePathing.whaleAtDark)
        {
            gameManager.bools.WhalePathing.forestToDark = false;
            gameManager.bools.WhalePathing.whaleReadyToLeaveForest = false;
        } else if (gameManager.bools.WhalePathing.whaleAtFlower)
        {
            gameManager.bools.WhalePathing.darkToFlower = false;
            gameManager.bools.WhalePathing.whaleReadyToLeaveDark = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            if (gameManager.hasBook)
            {
                if (gameManager.bools.whaleFed)
                {
                    if (gameManager.bools.WhalePathing.whaleAtTutorial)
                    {
                        GetOnWhale();
                    }
                    else if (gameManager.bools.WhalePathing.whaleAtForest &&
                             gameManager.bools.WhalePathing.whaleReadyToLeaveForest)
                    {
                        GetOnWhale();
                    }
                    else if (gameManager.bools.WhalePathing.whaleAtDark &&
                             gameManager.bools.WhalePathing.whaleReadyToLeaveDark)
                    {
                        GetOnWhale();
                    }
                }
                else
                {
                    if (gameManager.bools.FoodBools.whaleFood)
                    {
                        gameManager.DisplayBefriendSuccessText();
                        gameManager.bools.whaleFed = true;
                        gameManager.AddWhaleToBook();
                        gameManager.bools.AnimalsMetBools.WhaleMet = true;
                    }
                    else
                    {
                        gameManager.DisplayBefriendText();
                    }
                }
            }
        }
    }
}
