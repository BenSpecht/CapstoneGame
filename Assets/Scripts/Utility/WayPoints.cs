using System;
using System.Collections;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class WayPoints : MonoBehaviour {
    // put the points from unity interface
    public Transform[] forestToDark;
    public Transform[] darkToForest;
 
    public int currentWayPoint = 0; 
    Transform targetWayPoint;
 
    public float speed = 4f;

    public GameManager gameManager;
    public WhaleManager whaleManager;
    
    // Use this for initialization
    void Start () {
 
    }
     
    // Update is called once per frame
    void Update () {
        // // check if we have somewhere to walk
        // if(currentWayPoint < this.wayPointList.Length)
        // {
        //     if(targetWayPoint == null)
        //         targetWayPoint = wayPointList[currentWayPoint];
        //     Walk();
        // }
        
        // Check if we are walking
        if (gameManager.bools.WhalePathing.pathToDark)
        {
            if (targetWayPoint == null)
            {
                targetWayPoint = forestToDark[currentWayPoint];
            }

            if (currentWayPoint > forestToDark.Length)
            {
                // Stop movement and get player off of whale
                gameManager.bools.WhalePathing.whaleAtDark = true;
                currentWayPoint = 0;
                whaleManager.GetOffWhale();
            }
            else
            {
                Walk();
            }
        } else if (gameManager.bools.WhalePathing.pathToForest)
        {
            if (targetWayPoint == null)
            {
                targetWayPoint = darkToForest[currentWayPoint];
            }
            
            if (currentWayPoint > darkToForest.Length)
            {
                // Stop movement and get player off of whale
                gameManager.bools.WhalePathing.whaleAtForest = true;
                currentWayPoint = 0;
                whaleManager.GetOffWhale();
            }
            else
            {
                Walk();
            }
        }
    }

    private void Walk(){
        // rotate towards the target
        
        var transform1 = transform;
        var position = transform1.position;
        var position1 = targetWayPoint.position;

        var forward = transform.forward;
        forward = Vector3.RotateTowards(-transform1.forward, position1 - position, speed*Time.deltaTime, 0.0f);
        forward = -forward;
        transform.forward = forward;

        // move towards the target
        position = Vector3.MoveTowards(position, position1,   speed*Time.deltaTime);
        transform.position = position;

        if(transform.position == targetWayPoint.position)
        {
            currentWayPoint ++;
            if (gameManager.bools.WhalePathing.pathToDark)
            {
                if (currentWayPoint < forestToDark.Length)
                {
                    targetWayPoint = forestToDark[currentWayPoint];
                }
            } else if (gameManager.bools.WhalePathing.pathToForest)
            {
                if (currentWayPoint < darkToForest.Length)
                {
                    targetWayPoint = darkToForest[currentWayPoint];
                }
            }
        }
    } 
}