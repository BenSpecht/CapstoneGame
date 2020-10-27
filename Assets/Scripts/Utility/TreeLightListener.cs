using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeLightListener : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject treeLightAnimation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void TreeAnimationFinished()
    {
        gameManager.TreeLightAnimationOver();
    }
}