using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject repairText;
    public GameObject brokenBridge;
    public GameObject repairedBridge;
    
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
        Debug.Log("Beep");
        if (other.CompareTag("Player"))
        {
            if (gameManager.bools.InventoryBools.hasWood && brokenBridge.activeSelf)
            {
                repairText.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                brokenBridge.SetActive(false);
                repairedBridge.SetActive(true);
            }
        }
    }
}
