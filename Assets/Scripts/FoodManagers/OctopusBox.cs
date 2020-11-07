using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class OctopusBox : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject carryJar;

    public GameObject dropIcon;
    
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
        if (other.CompareTag("Player"))
        {
            
            gameManager.DisplayInteract();
        }
        Debug.Log(other.name);
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            dropIcon.SetActive(true);
            gameManager.DisplayFoundJartext();
            gameObject.SetActive(false);
            carryJar.SetActive(true);
            gameManager.bools.InventoryBools.hasOctopusBox = true;
        }
    }
}
