using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusManager : MonoBehaviour
{
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
            // Octopus shoots away
        }
    }

    public bool MoveToBox(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            return true;
        }

        return false;
    }
}
