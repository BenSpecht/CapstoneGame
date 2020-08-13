using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float speed = 5;
    public float gravity = -5;
 
    float _velocityY = 0; 
    
    CharacterController _controller;
    
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _velocityY += gravity * Time.deltaTime;
 
        var input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        input = input.normalized;
 
        var temp = Vector3.zero;
        switch (input.z)
        {
            case 1.0f:
                temp += transform.forward;
                break;
            case -1:
                temp += transform.forward * -1;
                break;
        }
 
        switch (input.x)
        {
            case 1:
                temp += transform.right;
                break;
            case -1:
                temp += transform.right * -1;
                break;
        }
 
        var velocity = temp * speed;
        velocity.y = _velocityY;
     
        _controller.Move(velocity * Time.deltaTime);
 
        if (_controller.isGrounded)
        {
            _velocityY = 0;
        }
    }
}
