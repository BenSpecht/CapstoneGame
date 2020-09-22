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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        playerObject.transform.localPosition = new Vector3(2.362f, -0.074f, -8.689f);
        playerObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

        // Disable player movement
        playerObject.GetComponent<ThirdPersonCharacter>().enabled = false;
        playerObject.GetComponent<ThirdPersonUserControl>().enabled = false;
        
        // Run whale movement
        if (gameManager.bools.WhalePathing.whaleAtForest)
        {
            gameManager.bools.WhalePathing.pathToDark = true;
            gameManager.bools.WhalePathing.whaleAtForest = false;
        } else if (gameManager.bools.WhalePathing.whaleAtDark)
        {
            gameManager.bools.WhalePathing.pathToForest = true;
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
        }
        
        playerObject.transform.rotation = Quaternion.identity;
        
        playerObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        playerObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        
        // Enable player movement
        playerObject.GetComponent<ThirdPersonCharacter>().enabled = true;
        playerObject.GetComponent<ThirdPersonUserControl>().enabled = true;

        // Disable whale movement
        if (gameManager.bools.WhalePathing.whaleAtDark)
        {
            gameManager.bools.WhalePathing.pathToDark = false;
        } else if (gameManager.bools.WhalePathing.whaleAtForest)
        {
            gameManager.bools.WhalePathing.pathToForest = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            if (gameManager.bools.whaleFed)
            {
                GetOnWhale();
            }
            else
            {
                if (gameManager.bools.FoodBools.whaleFood)
                {
                    gameManager.DisplayBefriendSuccessText();
                    gameManager.bools.whaleFed = true;
                    gameManager.AddWhaleToBook();
                }
                else
                {
                    gameManager.DisplayBefriendText();
                }
            }
        }
    }
}
