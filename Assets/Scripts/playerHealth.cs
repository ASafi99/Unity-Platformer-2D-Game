using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class playerHealth : MonoBehaviour
{

[SerializeField] private string newLevel;
    public restartGame theGameManager;

    public float fullHealth;
    public GameObject deathFX;
    
    public AudioClip playerHurt;
    
    float currentHealth;

    playerController controlMovement;

    public Text gameOverText;



    // AudioSource playerAS;

    bool damaged = false;
    Color damagedColour = new Color(0f,0f,0f,0.5f);
    float smoothColour =5f;
    public Image damageScreen;


    //HUD Variables
   public Slider healthSlider;
   public Text winGameScreen;
    // Start is called before the first frame update
    void Start()
    {
        
        currentHealth = fullHealth;
        controlMovement = GetComponent<playerController>();

        //hud initialisation
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;

        damaged = false;

        //playerAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if(damaged){
            damageScreen.color = damagedColour;

        }else{
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColour*Time.deltaTime);
        }
        
        damaged = false;
    }

    public void addDamage(float damage){

       

        if(damage<=0) return;
        
        currentHealth -= damage;

        Vector3 cameraZPos = new Vector3(transform.position.x,transform.position.y,Camera.main.transform.position.z);
      
 AudioSource.PlayClipAtPoint(playerHurt,cameraZPos,1f);

       //playerAS.PlayOneShot(playerHurt);

        healthSlider.value = currentHealth;


        damaged = true;

     
        if(currentHealth<=0){
            makeDead();
        }
    }

    public void addHealth(float healthAmount){
        currentHealth+=healthAmount;
        
        if(currentHealth>fullHealth)currentHealth=fullHealth;

        healthSlider.value = currentHealth;
    }

    public void makeDead(){

        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
        damageScreen.color = damagedColour;

        Animator winGameAnimator =  gameOverText.GetComponent<Animator>();
        winGameAnimator.SetTrigger("gameOver");

// Animator loseGameAnimator =  gameOverScreen.GetComponent<Animator>();
//         loseGameAnimator.SetTrigger("gameOver");

        // gameOverScreen.rectTransform.localScale = new Vector3(1.0f,1.0f,1.0f);
        theGameManager.restartTheGame();

        

    }

    

    public void winGame(){

  Destroy(gameObject);

  Animator winGameAnimator =  winGameScreen.GetComponent<Animator>();
    winGameAnimator.SetTrigger("gameOver");
         
    }

    private IEnumerator SomeCoroutine()
{
   
        Destroy(gameObject);
Animator winGameAnimator =  winGameScreen.GetComponent<Animator>();
        winGameAnimator.SetTrigger("gameOver");
        

         yield return new WaitForSeconds(3);

SceneManager.LoadSceneAsync(newLevel);
        
}
}
