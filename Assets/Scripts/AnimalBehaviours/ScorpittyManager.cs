using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScorpittyManager : MonoBehaviour
{
    private static readonly int Walking = Animator.StringToHash("Walking");
    
    public GameManager gameManager;

    public GameObject scropFoodCarry;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Scorpitty_walk"))
        {
            gameObject.GetComponent<WanderAI>().enabled = true;
            gameObject.GetComponent<NavMeshAgent>().isStopped = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            gameManager.DisplayInteract();
        }
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Detected");
            // Animation Control
            if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Scorpitty_walk"))
            {
                Debug.Log("Stopping movement");
                gameObject.GetComponent<Animator>().SetBool(Walking, false);
                gameObject.GetComponent<WanderAI>().enabled = false;
                gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            }

            if (Input.GetKeyDown(KeyCode.E) && gameManager.bools.FoodBools.scorpittyFood)
            {
                Debug.Log("Feeding Cat");
                // Animation Control
                gameObject.GetComponent<Animator>().Play("Scorpitty_meow");

                //Scorpitty Sounds
                void PlayScorpitty_Meow(string path)
                {

                    FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);

                }

                //FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Feed_Generic", GetComponent<Transform>().position);

                // Add to book
                scropFoodCarry.SetActive(false);
                gameManager.DisplayScropFedText();
                gameManager.AddScorpittyToBook();
                gameManager.bools.AnimalsMetBools.ScorpittyMet = true;
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
