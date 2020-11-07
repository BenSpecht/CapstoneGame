using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailbunnyManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject runTarget = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.bools.FoodBools.snailBunnyComingToFood)
        {
            if (runTarget != null)
            {
                RunTowardsFood();
            }
        }
    }

    public void SetTarget(GameObject target)
    {
        runTarget = target;
    }

    public void RunTowardsFood()
    {
        transform.position = Vector3.MoveTowards(transform.position, runTarget.transform.position, Time.deltaTime);

        if (Vector3.Distance(transform.position, runTarget.transform.position) < 0.001f)
        {
            gameManager.DisplayBerriesFedText();
            runTarget.SetActive(false);
            gameManager.bools.FoodBools.snailBunnyComingToFood = false;
            gameManager.AddSnailBunnyToBook();
            gameManager.bools.AnimalsMetBools.SnailbunnyMet = true;

            FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Feed_Generic", GetComponent<Transform>().position);
        }
    }
}
