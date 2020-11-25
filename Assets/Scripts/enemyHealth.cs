using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{

    public float enemyMaxHealth;

    public GameObject enemyDeathFX;

    float currentHealth;

    public bool drops;
    public GameObject theDrop;

    public AudioClip death;

   // public Slider enemy;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = enemyMaxHealth;

        //enemy.maxValue = enemyMaxHealth;
        //enemy.value = enemyMaxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamage(float damage){

        //enemySlider.gameObject.SetActive(true);

        currentHealth -= damage;

       // enemy.value = currentHealth;

        if(currentHealth<=0) makeDead();
    }

    void makeDead(){

        Destroy(gameObject.transform.parent.gameObject);

      Vector3 cameraZPos = new Vector3(transform.position.x,transform.position.y,Camera.main.transform.position.z);
      
 AudioSource.PlayClipAtPoint(death,cameraZPos,1f);

        Instantiate(enemyDeathFX, transform.position, transform.rotation);

        if(drops)Instantiate(theDrop,transform.position,transform.rotation);
    }
}
