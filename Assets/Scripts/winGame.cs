﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class winGame : MonoBehaviour
{

    
    [SerializeField] public string level;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

       
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag =="Player"){

           SceneManager.LoadScene(level);

        }

        
    }
}
