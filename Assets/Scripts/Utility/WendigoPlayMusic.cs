using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Utility;

public class WendigoPlayMusic : MonoBehaviour
{
    public GameManager gameManager;
    public GameManager wendigoObject;
    private static readonly int WendigoMoving = Animator.StringToHash("wendigoMoving");

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
        if (other.CompareTag("Player") && gameManager.bools.InventoryBools.hasInstrument)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Player/PanFlute_FlowerSnake", GetComponent<Transform>().position);
            // Add wendigo to book
            gameManager.AddWendigoToBook();
            gameManager.bools.AnimalsMetBools.WendigoMet = true;
            
            // Stop in place and idle
            wendigoObject.GetComponent<WendigoWaypoint>().enabled = false;
            wendigoObject.GetComponent<NavMeshAgent>().enabled = false;
            wendigoObject.GetComponent<Animator>().SetBool(WendigoMoving, false);
        }
    }
}
