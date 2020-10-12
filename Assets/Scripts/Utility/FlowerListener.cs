using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerListener : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject flowerAnimation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void AnimationFinished()
    {
        gameManager.FlowerAnimationOver();
    }

    void FlowerOpened()
    {
        flowerAnimation.GetComponent<Animator>().enabled = false;
    }
}
