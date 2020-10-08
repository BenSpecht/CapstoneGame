using UnityEngine;
using UnityEngine.AI;

namespace Utility
{
    public class WendigoWaypoint : MonoBehaviour {
        // put the points from unity interface
        public Transform[] WendigoOut;
        public Transform[] WendigoCircle;
 
        public int currentWayPoint = 0; 
        public Transform targetWayPoint;
 
        public float speed = 4f;

        public GameManager gameManager;

        public bool wendigoOutBool;
        public bool wendigoCircleBool;
        private static readonly int WendigoMoving = Animator.StringToHash("wendigoMoving");

        // Use this for initialization
        void Start () {
 
        }
     
        // Update is called once per frame
        void Update () {
            // Check if we are walking
            
            if (wendigoCircleBool) 
            {
                if (currentWayPoint > WendigoCircle.Length)
                {
                    // Reached Destination
                    Debug.Log("HAHA");
                }
                else
                {
                    if (targetWayPoint == null)
                    {
                        targetWayPoint = WendigoCircle[currentWayPoint];
                    }
                }
                
                Walk();
            }
            
            if (wendigoOutBool)
            {
                if (currentWayPoint > WendigoOut.Length)
                {
                    // Reached destination
                    gameObject.GetComponent<Animator>().SetBool(WendigoMoving, false);
                    gameObject.GetComponent<Animator>().Play("Wendigo_Roar");
                    wendigoOutBool = false;
                    wendigoCircleBool = true;
                    currentWayPoint = 0;
                    targetWayPoint = null;
                }
                else
                {
                    if (targetWayPoint == null)
                    {
                        targetWayPoint = WendigoOut[currentWayPoint];
                    }
                    
                    Walk();
                }
            }
        }

        private void Walk(){
            // Run animation
            gameObject.GetComponent<Animator>().SetBool(WendigoMoving, true);

            if (!gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Wendigo_Idle"))
            {

                if (wendigoCircleBool)
                {
                    Debug.Log("MEME");
                }

                // rotate towards the target

                var transform1 = transform;
                var position = transform1.position;
                var position1 = targetWayPoint.position;

                var forward = transform.forward;
                forward = Vector3.RotateTowards(-transform1.forward, position1 - position, speed * Time.deltaTime,
                    0.0f);
                forward = -forward;
                transform.forward = forward;

                // move towards the target
                // position = Vector3.MoveTowards(position, position1,   speed*Time.deltaTime);
                // transform.position = position;

                gameObject.GetComponent<NavMeshAgent>().SetDestination(targetWayPoint.transform.position);

                if (Mathf.Abs(transform.position.x - targetWayPoint.position.x) < 0.001f)
                {
                    currentWayPoint++;
                    // Update target

                    if (wendigoOutBool)
                    {
                        if (currentWayPoint < WendigoOut.Length)
                        {
                            targetWayPoint = WendigoOut[currentWayPoint];
                        }
                    }
                    else if (wendigoCircleBool)
                    {
                        if (currentWayPoint < WendigoCircle.Length)
                        {
                            targetWayPoint = WendigoCircle[currentWayPoint];
                        }
                    }
                }
            }
        } 
    }
}