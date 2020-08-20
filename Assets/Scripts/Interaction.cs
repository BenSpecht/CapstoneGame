using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Interaction : MonoBehaviour
{

    [FormerlySerializedAs("BirdInteract")] public GameObject birdInteract;

    [FormerlySerializedAs("Planks")] public GameObject planks;

    public GameObject gather;
    public GameObject repair;

    public GameObject bridge;
    public GameObject brokenbridge;
    
    


    private bool _holdingPlanks = false;

    private bool _birdPress = true;

    private bool _birdDone = false;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_birdDone == true)
        {
            birdInteract.SetActive(false);
            
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Bird"))
        {
            Debug.Log("Hi");
            birdInteract.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("WORK");
                planks.SetActive(true);
                _birdDone = true;


            }
            
            
            
        }

        if (other.gameObject.CompareTag("Planks"))
        {
            if (_birdDone == true)
            {
                gather.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("WORK");
                    planks.SetActive(false);
                    _holdingPlanks = true;


                }
                
            }
            
            
            
        }

        if (other.gameObject.CompareTag("Bridge"))
        {
            Debug.Log("Broken");
            if (_holdingPlanks == true)
            {
                repair.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    brokenbridge.SetActive(false);
                    bridge.SetActive(true);
                    
                    
                }
                
                
                
                
            }
            
            
        }
        
        
       
    }

    private void OnTriggerExit(Collider other)
    {
        birdInteract.SetActive(false);
    }
    
    
}
