using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed;
    public Transform groundCheck;
    public float groundChekrRadius = 0.5f;
    public LayerMask layerName;

    public Joystick joyStick;
    Vector3 velocity;
    float gravity = -9.81f;
    bool isGround;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        PlayerMovement();
        PlayerGravity();
        PlayerVelocity();
       
    }

   

    private void PlayerGravity()
    {
        isGround = Physics.CheckSphere(groundCheck.position, groundChekrRadius, layerName);
        if(isGround&&velocity.y<0)
        {
            velocity.y  = -2f;
        }
    }

    private void PlayerMovement()
    {
        float x = joyStick.Horizontal * moveSpeed;
        float z = joyStick.Vertical * moveSpeed;

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * Time.deltaTime);
    }

    private void PlayerVelocity()
    {
        velocity.y += gravity * Time.deltaTime * Time.deltaTime;
        controller.Move(velocity);
    }
}
