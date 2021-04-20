﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2;
    public float jumpForce = 5f; 
    public float climbSpeed = 2;
    public  Rigidbody2D rb2D;
    private float horizontalMovement;

    public int facing = 1;
    public bool canMove = true;
    public CircleCollider2D myFeet;
    private float  gravityScaler;
    // Start is called before the first frame update
    void Start()
    {
        //rb2D = GetComponent<Rigidbody2D>();
        gravityScaler =  rb2D.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        float flipX = Input.GetAxisRaw("Horizontal");

        if(flipX != 0 && canMove == true){
            FlipPlayer(flipX);
        }

        if(Input.GetButtonDown("Jump") && myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            Vector2 jumpVelocity = new Vector2(0f,jumpForce);
            rb2D.velocity += jumpVelocity;
            //rb2D.AddForce(jumpVelocity);
        }

        ClimbLadder();
    }

    private void FixedUpdate(){
        Walk();
    }
    
    public void Walk(){
        Vector2 playerVelocity = new Vector2(horizontalMovement * moveSpeed, rb2D.velocity.y);
        rb2D.velocity = playerVelocity;
    }

    public void FlipPlayer(float x){
        transform.localScale = new Vector2(x,transform.localScale.y);
        facing = (int)x;
    }

    public void ClimbLadder()
    {
        if(!myFeet.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            rb2D.gravityScale = gravityScaler;
            return;
        }
        float verticalMovement = Input.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(0,verticalMovement * climbSpeed);
        rb2D.gravityScale = 0;
        rb2D.velocity = climbVelocity;
    }

}
