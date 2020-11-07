using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class BellController : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject Wendigo;
    public GameObject BellCamera;
    public GameObject NewPlayerPosition;
    public GameObject Player;
    public GameObject MainCamera;

    public GameObject carryflute;

    public GameObject wendi;

    public bool flute;
    
    // Start is called before the first frame update
    void Start()
    {
        flute = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (carryflute.activeInHierarchy == true)
        {
            flute = true;


        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (flute == true)
        {
            if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E)) 
            {
                // Ring bell
                FMODUnity.RuntimeManager.PlayOneShot("event:/TowerBell", GetComponent<Transform>().position);

                // Disable Player Control
                gameManager.bools.ControlBools.playerControl = false;
            
                // Enable Cinemachine
                MainCamera.GetComponent<MouseOrbitImproved>().enabled = false;
                MainCamera.GetComponent<CinemachineBrain>().enabled = true;
            
                // Set VCam prio to high
                BellCamera.GetComponent<CinemachineVirtualCamera>().Priority = 1000000;
            
                // Move player to location
                Player.transform.position = NewPlayerPosition.transform.position;
            
                // Play animation
                BellCamera.GetComponent<Animation>().Play();
                //Wendigo.GetComponent<WendigoManager>().WendigoAwaken();
                wendi.gameObject.SetActive(true);
            }
            
            
            
            
            
            
            
            
            
            
            
            
            
        }
       
    }

    public void BellFinishedAnimation()
    {
        // Set camera to default
        MainCamera.GetComponent<CinemachineBrain>().enabled = false;
        MainCamera.GetComponent<MouseOrbitImproved>().enabled = true;
        
        // Reset VCam prio
        BellCamera.GetComponent<CinemachineVirtualCamera>().Priority = 1;
        
        // Return player control
        gameManager.bools.ControlBools.playerControl = true;

    } 
}
