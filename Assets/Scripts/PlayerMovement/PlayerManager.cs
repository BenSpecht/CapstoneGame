using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public GameObject whaleCameraParent;
    public GameObject gameManager;
    public GameObject playerCameraParent;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Whale")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                playerCameraParent.SetActive(false);
                whaleCameraParent.SetActive(true);

                // Animate player getting on whale here - for now just teleporting player onto whale
                var player = gameObject;
                player.transform.parent = other.transform;
                player.transform.localPosition = new Vector3(1.1f, -0.28f, -1.7f);
                player.GetComponent<ThirdPersonPlayerController>().gravity = 0;
                
                var gameManagerScript = gameManager.GetComponent<GameManager>();    
                gameManagerScript.bools.ControlBools.playerControl = false;
                gameManagerScript.bools.ControlBools.whaleControl = true;
            }
        }
    }
}
