using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    Rigidbody2D rigidBody;
    Animator anim;

    float jumpForce = 15;

    public bool canJump;

    public float speed;

    float masterSpeed;
    bool canMoveL, canMoveR;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        masterSpeed = speed;        
    }


    void FixedUpdate()
    {
        //get right/left input information
        float horizontal = Input.GetAxis("Horizontal");

        if(horizontal < 0 && transform.position.x >= -6.5f){
            transform.position += new Vector3(horizontal, 0) * Time.deltaTime * speed;
        }
        if(horizontal > 0 && transform.position.x <= 6.5f){
            transform.position += new Vector3(horizontal, 0) * Time.deltaTime * speed;
        }

        //get vertical velocity
        float verticalMovement = rigidBody.velocity.y;
        //if player is in the air, decrease speed
        if (verticalMovement != 0)
        {
            speed = masterSpeed / 1.8f;

            anim.SetBool("isIdle", false);
            anim.SetBool("isJumping", true);
        }
        else
        {
            speed = masterSpeed;

            anim.SetBool("isIdle", true);
            anim.SetBool("isJumping", false); 
        }

        if(canJump && Input.GetButtonDown("Jump"))
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (rigidBody.velocity.y > -0.5 && rigidBody.velocity.y < 0.5)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }

        //move player left and right according to user input and speed
    }
}

