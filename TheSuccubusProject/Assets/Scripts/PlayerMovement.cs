﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rigidbody2D;
    public CharacterController2D controller;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    public float runSpeed = 40f;
    public HalfBody halfBody;
    bool halfBodyMode = false;
    // Update is called once per frame
    void Update()
    {
        //get movement
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;
        
        //animator
        animator.SetFloat("isWalking", Mathf.Abs(horizontalMove));
        
        //check the horizontal move
        Debug.Log("Horizontal: "+horizontalMove);
        
        //detach body
        if (Input.GetKeyDown("space")) {

        
            halfBody.HalfMode();
            halfBodyMode = true;
            animator.SetBool("isDetached", true);


        }
        //release detach
      else if (Input.GetKeyUp("space")) {
            
            halfBodyMode = false;
            Debug.Log("Hi " + halfBodyMode);
            animator.SetBool("isDetached", false);
            halfBody.ReturnBody();

        }
    }

    void FixedUpdate() {

        if (halfBodyMode == true) {

            Debug.Log("Vertical: " + verticalMove);
            Debug.Log("Half body mode is true: " + halfBodyMode);
            controller.Move(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime, true, false);



        }
        else if(halfBodyMode == false) {

            Debug.Log("Half body mode is false: " + halfBodyMode);
            controller.Move(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime, false, false);

        }

    }
    
}
