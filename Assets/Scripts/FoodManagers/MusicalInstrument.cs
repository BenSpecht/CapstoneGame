using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicalInstrument : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject carryFlute;
    
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
            gameManager.bools.InventoryBools.hasInstrument = true;
            gameObject.SetActive(false);
            carryFlute.SetActive(true);
            gameManager.DisplayInstrumentRecieved();
        }
    }
}
