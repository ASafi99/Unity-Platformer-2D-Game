﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public float maxSpeed;

    Rigidbody2D myRB;
    Animator myAnim;

    bool facingRight;

    //jumping var

    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    //for shooting 

    public Transform gunTip;
    public GameObject bullet; 
    float fireRate = 0.5f;
    float nextFire = 0f;
    // Start is called before the first frame update
    void Start()
    {


        myRB= GetComponent<Rigidbody2D>();
        myAnim= GetComponent<Animator>();

        facingRight = true;

        
        
    }

    void Update(){
        
         //player shooting
        

     if(Input.GetAxisRaw("Fire1")>0) {
            fireRocket();
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        

        if(grounded && Input.GetAxis("Jump")>0){

            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            myRB.AddForce(new Vector2(0,jumpHeight));
        }

       
        //check if we are grounded - if no, we are falling
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius,groundLayer);
         myAnim.SetBool("isGrounded", grounded);

        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);

        float move = Input.GetAxis("Horizontal");

        myAnim.SetFloat("speed", Mathf.Abs(move));

        myRB.velocity = new Vector2(move*maxSpeed,myRB.velocity.y);

        if(move>0 && !facingRight ){

            flip();

        }else if(move<0 &&facingRight){
            flip();
        }
        
    }

    void flip(){

        facingRight=!facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;

        transform.localScale= theScale;
    }

    void fireRocket(){

        if(Time.time > nextFire){

            nextFire = Time.time + fireRate;
        
        if(facingRight){
            Instantiate(bullet, gunTip.position,Quaternion.Euler (new Vector3 (0,0,0)));

        }else if(!facingRight){
            Instantiate(bullet, gunTip.position,Quaternion.Euler (new Vector3 (0,0,180f)));
        }
        }
    }
}
