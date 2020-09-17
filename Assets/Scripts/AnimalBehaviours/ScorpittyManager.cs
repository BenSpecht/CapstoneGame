using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpittyManager : MonoBehaviour
{
    private static readonly int Walking = Animator.StringToHash("Walking");
    
    public GameManager gameManager;

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
            // Animation Control
            if (!gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Scorpitty_WalkToSit") &&
                !gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Scorpitty_Idle"))
            {
                gameObject.GetComponent<Animator>().SetBool(Walking, false);
            }

            if (Input.GetKeyDown(KeyCode.E) && gameManager.bools.FoodBools.scorpittyFood)
            {
                // Animation Control
                gameObject.GetComponent<Animator>().Play("Scorpitty_Meow");
                
                // Add to book
                gameManager.AddScorpittyToBook();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<Animator>().SetBool(Walking, true);
        }
    }
}
