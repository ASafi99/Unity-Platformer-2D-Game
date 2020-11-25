using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAI : MonoBehaviour{
  public float enemySpeed;

    Animator enemyAnimator;

    //facing
    public GameObject enemyGraphic;
    bool canFlip = true;
    bool facingRight = false;
    float flipTime = 5f;
    float nextFlipChance = 0f;
    public Transform player, shootPos, shootPos1;
    public float range;
    float distToPlayer;

    bool canShoot;

    //attacking
    public float chargeTime;
    float startChargeTime;
    bool charging; 
    Rigidbody2D enemyRB;
    public GameObject bullet;

    Rigidbody2D myRB;

    // Start is called before the first frame update
    void Start()
    {

        enemyAnimator = GetComponentInChildren<Animator>();
        enemyRB= GetComponent<Rigidbody2D>();
        canShoot=true;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextFlipChance){
            if(Random.Range(0,10)>=5) flipFacing();
            nextFlipChance = Time.time +flipTime;
        }

        // distToPlayer= Vector2.Distance(transform.position, player.position);

        // if(distToPlayer<= range){

            // if(player.position.x > transform.position.x && transform.localScale.x<0){
            
        // }
        

    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){

            if(facingRight && other.transform.position.x < transform.position.x){
                flipFacing();
                // if(canShoot)
                // StartCoroutine(Shoot());
            }else if(!facingRight && other.transform.position.x > transform.position.x){
                flipFacing();
                // if(canShoot)
                // StartCoroutine(Shoot1());
            } 

            canFlip= false; 
            charging = true;
            startChargeTime = Time.time +chargeTime;
        }
    }

     

    void OnTriggerStay2D(Collider2D other){

        if(other.gameObject.tag == "Player"){
            if(startChargeTime < Time.time){
                if(!facingRight){ enemyRB.AddForce(new Vector2(-1,0)*enemySpeed);
                if(canShoot)
                StartCoroutine(Shoot());
                }
               
                else{enemyRB.AddForce(new Vector2(1,0)*enemySpeed);
                if(canShoot)
                StartCoroutine(Shoot1());
                }
                
             
            }
            
        }
        }

    

    void OnTriggerExit2D(Collider2D other){

        if (other.gameObject.tag == "Player"){

            canFlip = true;
            charging = false;
            enemyRB.velocity = new Vector2(0f,0f);
            
            
        }
    }

    void flipFacing(){

        if(!canFlip) return;

        float facingX= enemyGraphic.transform.localScale.x;

        facingX *= -1f;

        enemyGraphic.transform.localScale = new Vector3(facingX,enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);

        facingRight = !facingRight;

    }

    IEnumerator Shoot(){

        canShoot = false;

        yield return new WaitForSeconds(1);

        GameObject newBullet = Instantiate(bullet,shootPos.position,Quaternion.Euler (new Vector3 (0,0,180f)));
   
 //newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(100,50),ForceMode2D.Impulse);
 newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-40,0f);
        canShoot = true;
    }


    IEnumerator Shoot1(){


        canShoot = false;

        yield return new WaitForSeconds(1);

        GameObject newBullet = Instantiate(bullet,shootPos1.position,Quaternion.Euler (new Vector3 (0,0,0)));
       newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(40,0f);
 //newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100,50),ForceMode2D.Impulse);

        
        canShoot = true;
    
}
}
