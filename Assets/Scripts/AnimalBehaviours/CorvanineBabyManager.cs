using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class CorvanineBabyManager : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject carry;
    
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
            gameManager.bools.InventoryBools.hasCovanineBaby = true;
            carry.SetActive(true);
            gameObject.SetActive(false);
            gameManager.DisplayBabySaved();
            
        }
    }
}
