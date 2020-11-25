using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public float weaponDamage;

	 public float bulletSpeed;

     public GameObject explosionEffect;

    Rigidbody2D myRB;
    // Start is called before the first frame update
    void Awake()
    {


        myRB = GetComponent<Rigidbody2D>();

        // if(transform.localRotation.z>0){

        // myRB.AddForce(new Vector2(-1,0)*bulletSpeed,ForceMode2D.Impulse);
        // }
        // else
        // {
        //   myRB.AddForce(new Vector2(1,0)*bulletSpeed,ForceMode2D.Impulse);
            
        // }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            
               playerHealth hurtEnemy = other.gameObject.GetComponent<playerHealth>();
                hurtEnemy.addDamage(weaponDamage);

            
        }
    }

    void OnTriggerStay2D(Collider2D other){

        if(other.gameObject.tag == "Player"){
            removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);

     
                 playerHealth hurtEnemy = other.gameObject.GetComponent<playerHealth>();
                hurtEnemy.addDamage(weaponDamage);

            }
        }

    // Update is called once per frame
    void Update()
    {
        
    }

     void removeForce(){
        myRB.velocity = new Vector2(0,0);
        
    }
} 

