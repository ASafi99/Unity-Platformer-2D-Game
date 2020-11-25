using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveScenes : MonoBehaviour
{
    public delegate void Change();
    public static event Change TimeChanged;

     public Text winGameScreen;

    public void Start()
    {
       

       SceneManager.LoadSceneAsync("level2");
        
    }

    public void Update(){

        Animator winGameAnimator =  winGameScreen.GetComponent<Animator>();
         winGameAnimator.SetTrigger("gameOver");
    }

   

    public void ChangeScene(string level)
    {
     
        SceneManager.LoadScene(level);

      
    }

  
}