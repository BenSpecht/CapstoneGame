using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerpanceaeManager : MonoBehaviour
{
    public GameObject[] serpanceaeMembers;
    private static readonly int PlayerInRange = Animator.StringToHash("PlayerInRange");

    public GameManager gameManager;
    public Collider invisibleWall;
    private static readonly int PlayerPlayedMusic = Animator.StringToHash("PlayerPlayedMusic");

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
            foreach (var serpanceae in serpanceaeMembers)
            {
                serpanceae.GetComponent<Animator>().SetBool(PlayerInRange, true);
            }

            if (gameManager.bools.InventoryBools.hasInstrument && Input.GetKeyDown(KeyCode.E))
            {
                foreach (var serpanceae in serpanceaeMembers)
                {
                    serpanceae.GetComponent<Animator>().Play("Serpanceae_Dance");
                    serpanceae.GetComponent<Animator>().SetBool(PlayerPlayedMusic, true);
                    invisibleWall.enabled = false;
                    
                    // Add to book
                    gameManager.AddSerpanceaeToBook();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var serpanceae in serpanceaeMembers)
            {
                serpanceae.GetComponent<Animator>().SetBool(PlayerInRange, false);
            }
        }
    }
}
