using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other);
        if (other.gameObject.name == "Whale")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject.Find("PlayerCameraParent").SetActive(false);
                GameObject.Find("WhaleCameraParent").SetActive(true);
                
                // Animate player getting on whale here - for now just teleporting player onto whale
                var player = gameObject;
                player.transform.parent = other.transform;
                player.transform.position = new Vector3(1.1f, -0.28f, -1.7f);
                
                var gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();    
                gameManager.playerControl = false;
                gameManager.whaleControl = true;
            }
        }
    }
}
