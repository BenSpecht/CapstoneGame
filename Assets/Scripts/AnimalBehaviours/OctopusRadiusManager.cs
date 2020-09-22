using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusRadiusManager : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject octopus;
    
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
            }
        }
    }
}
