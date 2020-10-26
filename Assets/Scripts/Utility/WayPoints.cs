using System;
using System.Collections;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class WayPoints : MonoBehaviour {
    // put the points from unity interface
    public Transform[] tutorialToForest;
    public Transform[] forestToDark;
    public Transform[] darkToFlower;

    public Transform[] whaleCircleForest;
    public Transform[] whaleCircleDark;

    public Transform[] whaleApproachForest;
    public Transform[] whaleApproachDark;
 
    public int currentWayPoint = 0; 
    Transform targetWayPoint;
 
    public float speed = 4f;

    public GameManager gameManager;
    public WhaleManager whaleManager;

    private bool approachedForest = false;
    private bool approachedDark = false;
    
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
        
        // Tutorial To Forest
        if (gameManager.bools.WhalePathing.tutorialToForest)
        {
            if (targetWayPoint == null)
            {
                targetWayPoint = tutorialToForest[currentWayPoint];
            }

            if (currentWayPoint > tutorialToForest.Length)
            {
                // Stop movement and get player off of whale
                gameManager.bools.WhalePathing.whaleAtForest = true;
                currentWayPoint = 0;
                whaleManager.GetOffWhale();
                targetWayPoint = null;
            }
            else
            {
                Walk();
            }
            // Forest To Dark
        } else if (gameManager.bools.WhalePathing.forestToDark)
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
                targetWayPoint = null;
            }
            else
            {
                Walk();
            }
        } else if (gameManager.bools.WhalePathing.whaleCircleForest)
        {
            if (targetWayPoint == null)
            {
                targetWayPoint = whaleCircleForest[currentWayPoint];
            }

            if (currentWayPoint > whaleCircleForest.Length)
            {
                currentWayPoint = 0;
                if (gameManager.bools.WhalePathing.whaleReadyToLeaveForest)
                {
                    gameManager.bools.WhalePathing.whaleCircleForest = false;
                }
                targetWayPoint = null;
            }
            else
            {
                Walk();
            }
        } else if (gameManager.bools.WhalePathing.whaleReadyToLeaveForest &&
                   !gameManager.bools.WhalePathing.whaleCircleForest && !approachedForest)
        {
            if (targetWayPoint == null)
            {
                targetWayPoint = whaleApproachForest[currentWayPoint];
            }

            if (currentWayPoint > whaleApproachForest.Length)
            {
                currentWayPoint = 0;
                approachedForest = true;
                targetWayPoint = null;
            }
            else
            {
                Walk();
            }
        } else if (gameManager.bools.WhalePathing.whaleCircleDark)
        {
            if (targetWayPoint == null)
            {
                targetWayPoint = whaleCircleDark[currentWayPoint];
            }

            if (currentWayPoint > whaleCircleDark.Length)
            {
                currentWayPoint = 0;
                if (gameManager.bools.WhalePathing.whaleReadyToLeaveDark)
                {
                    gameManager.bools.WhalePathing.whaleCircleDark = false;
                }

                targetWayPoint = null;
            }
            else
            {
                Walk();
            }
        } else if (gameManager.bools.WhalePathing.whaleReadyToLeaveDark &&
                   !gameManager.bools.WhalePathing.whaleCircleDark && !approachedDark)
        {
            if (targetWayPoint == null)
            {
                targetWayPoint = whaleApproachDark[currentWayPoint];
            }

            if (currentWayPoint > whaleApproachDark.Length)
            {
                currentWayPoint = 0;
                gameManager.bools.WhalePathing.whaleCircleDark = false;
                approachedDark = true;
                targetWayPoint = null;
            }
            else
            {
                Walk();
            }
        } else if (gameManager.bools.WhalePathing.darkToFlower)
        {
            if (targetWayPoint == null)
            {
                targetWayPoint = darkToFlower[currentWayPoint];
            }

            if (currentWayPoint > darkToFlower.Length)
            {
                gameManager.bools.WhalePathing.whaleAtFlower = true;
                currentWayPoint = 0;
                whaleManager.GetOffWhale();
                targetWayPoint = null;
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
            if (gameManager.bools.WhalePathing.tutorialToForest)
            {
                if (currentWayPoint < tutorialToForest.Length)
                {
                    targetWayPoint = tutorialToForest[currentWayPoint];
                }
            } else if (gameManager.bools.WhalePathing.forestToDark)
            {
                if (currentWayPoint < forestToDark.Length)
                {
                    targetWayPoint = forestToDark[currentWayPoint];
                }
            } else if (gameManager.bools.WhalePathing.whaleCircleForest)
            {
                if (currentWayPoint < whaleCircleForest.Length)
                {
                    targetWayPoint = whaleCircleForest[currentWayPoint];
                }
            } else if (gameManager.bools.WhalePathing.whaleReadyToLeaveForest &&
                       !gameManager.bools.WhalePathing.whaleCircleForest)
            {
                if (currentWayPoint < whaleApproachForest.Length)
                {
                    targetWayPoint = whaleApproachForest[currentWayPoint];
                }
            } else if (gameManager.bools.WhalePathing.whaleCircleDark)
            {
                if (currentWayPoint < whaleCircleDark.Length)
                {
                    targetWayPoint = whaleCircleDark[currentWayPoint];
                }
            } else if (gameManager.bools.WhalePathing.whaleReadyToLeaveDark &&
                       !gameManager.bools.WhalePathing.whaleCircleDark && !gameManager.bools.WhalePathing.darkToFlower)
            {
                if (currentWayPoint < whaleApproachDark.Length)
                {
                    targetWayPoint = whaleApproachDark[currentWayPoint];
                }
            } else if (gameManager.bools.WhalePathing.darkToFlower)
            {
                if (currentWayPoint < darkToFlower.Length)
                {
                    targetWayPoint = darkToFlower[currentWayPoint];
                }
            }
        }
    } 
}