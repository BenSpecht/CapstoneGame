using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OctopusRadiusManager : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject octopus;
    public GameObject octopusFilled;
    public GameObject otherOctopus;
    
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
        Debug.Log(other.tag);
        if (other.CompareTag("OctopusBox"))
        {
            Debug.Log("Box Found");
            if (octopus.GetComponent<OctopusManager>().MoveToBox(other.transform))
            {
                octopus.SetActive(false);
                gameManager.AddOctopusToBook();
                gameManager.bools.AnimalsMetBools.OctopusMet = true;
                octopusFilled.SetActive(true);
                otherOctopus.SetActive(false);
                octopusFilled.transform.position = other.transform.position;
                other.gameObject.SetActive(false);
            }
        }
    }
}
