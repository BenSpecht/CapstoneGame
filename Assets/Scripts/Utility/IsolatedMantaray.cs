 // using UnityEngine;
//
// public class IsolatedMantaray : MonoBehaviour {
//  
//     // put the points from unity interface
//     public Transform[] wayPointList;
//  
//     public int currentWayPoint = 0; 
//     Transform targetWayPoint;
//  
//     public float speed = 4f;
//  
//     // Use this for initialization
//     void Start () {
//  
//     }
//      
//     // Update is called once per frame
//     void Update () {
//         // check if we have somewere to walk
//         if(currentWayPoint < this.wayPointList.Length)
//         {
//             if(targetWayPoint == null)
//                 targetWayPoint = wayPointList[currentWayPoint];
//             walk();
//         }
//     }
//  
//     void walk(){
//         // rotate towards the target
//         transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed*Time.deltaTime, 0.0f);
//  
//         // move towards the target
//         transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position,   speed*Time.deltaTime);
//  
//         if(transform.position == targetWayPoint.position)
//         {
//             switch (currentWayPoint)
//             {
//                 case 0:
//                     currentWayPoint = 2;
//                     break;
//                 case 1:
//                     currentWayPoint = 0;
//                     break;
//                 case 2:
//                     currentWayPoint = 1;
//                     break;
//             }
//             targetWayPoint = wayPointList[currentWayPoint];
//         }
//     } 
// }

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class IsolatedMantaray : MonoBehaviour {
    // put the points from unity interface
    public Transform[] MantarayTrack;
 
    public int currentWayPoint = 0; 
    Transform targetWayPoint;
 
    public float speed = 4f;

    public GameManager gameManager;
    public MantarayManager mantarayManager;

    
    // Use this for initialization
    void Start () {
 
    }
     
    // Update is called once per frame
    void Update () {
        if (targetWayPoint == null)
        {
            targetWayPoint = MantarayTrack[currentWayPoint];
        }

        if (currentWayPoint > MantarayTrack.Length)
        {
            currentWayPoint = 0;
        }
        else
        {
            Walk();
        }
    }

    private void Walk(){
        // rotate towards the target
        
        var transform1 = transform;
        var position = transform1.position;
        var position1 = targetWayPoint.position;

        var forward = transform.forward;
        forward = Vector3.RotateTowards(transform1.forward, position1 - position, speed*Time.deltaTime, 0.0f);
        // forward = -forward;
        transform.forward = forward;

        // move towards the target
        position = Vector3.MoveTowards(position, position1,   speed*Time.deltaTime);
        transform.position = position;

        if(transform.position == targetWayPoint.position)
        {
            currentWayPoint ++;
            if (currentWayPoint < MantarayTrack.Length)
            {
                targetWayPoint = MantarayTrack[currentWayPoint];
            }
        }
    } 
}