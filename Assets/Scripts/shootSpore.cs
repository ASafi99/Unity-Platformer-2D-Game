﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootSpore : MonoBehaviour
{

    public GameObject theProjectile;
    public float shootTime;
    public Transform shootFrom;
    public int chanceShoot;

    float nextShootTime;
    Animator cannonAnim;
    // Start is called before the first frame update
    void Start()
    {

        cannonAnim = GetComponentInChildren<Animator>();
        nextShootTime = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.tag == "Player" && nextShootTime<Time.time){
            nextShootTime = Time.time+shootTime;
            if(Random.Range(0,10)>=chanceShoot){
                Instantiate(theProjectile,shootFrom.position, Quaternion.identity);
                cannonAnim.SetTrigger("cannonShoot");
            }
        }
    }

    // void OnTriggerExit2D(Collider2D other){

    //     if (other.gameObject.tag == "Player"){

    //       cannonAnim.ResetTrigger("cannonShoot");

    //     }   

}
