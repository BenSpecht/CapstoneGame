using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodScript : MonoBehaviour
{
    
    public GameManager gameManager;

    public GameObject carryPlanks;
    // Start is called before the first frame update
    
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            gameManager.DisplayInteract();
        }
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            
                // Add to journal and provide wood
                carryPlanks.SetActive(true);
                gameManager.bools.InventoryBools.hasWood = true;
                gameManager.DisplayWoodRecieved();
                FMODUnity.RuntimeManager.PlayOneShot("event:/Planks/Planks_PickUp", GetComponent<Transform>().position);
                gameObject.SetActive(false);
        }
    }
}
