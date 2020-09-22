using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantarayManager : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Swim"))
        {
            gameObject.GetComponent<IsolatedMantaray>().enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            if (gameManager.bools.FoodBools.mantarayFood)
            {
                // Stop mantaray movement
                gameObject.GetComponent<IsolatedMantaray>().enabled = false;
                // Play mantaray eating animation
                gameObject.GetComponent<Animator>().Play("Eat");
                gameManager.AddMantarayToBook();
            }
        }
    }
}
