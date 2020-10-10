using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraListenerController : MonoBehaviour
{

    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var tempTransform = transform.position;
        tempTransform = player.transform.position;
        tempTransform.y += 1.3f;
        gameObject.transform.position = tempTransform;
    }
}
