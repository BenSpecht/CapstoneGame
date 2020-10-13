using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailbunnyFeedController : MonoBehaviour
{
    List <GameObject> currentCollisions = new List <GameObject> ();

    public GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject closest = null;
        float maxDistance = 0;
        foreach (var snailBunny in currentCollisions)
        {
            var tempDistance = Vector3.Distance(gameObject.transform.position, snailBunny.transform.position);
            if (tempDistance > maxDistance)
            {
                maxDistance = tempDistance;
                closest = snailBunny;
            }    
        }

        if (!gameManager.bools.FoodBools.snailBunnyComingToFood && closest != null)
        {
            gameManager.bools.FoodBools.snailBunnyComingToFood = true;
            closest.GetComponent<SnailbunnyManager>().runTarget = gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!currentCollisions.Contains(other.gameObject) && other.CompareTag("SnailBunny"))
        {
            currentCollisions.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (currentCollisions.Contains(other.gameObject))
        {
            currentCollisions.Remove(other.gameObject);
        }
    }
}
