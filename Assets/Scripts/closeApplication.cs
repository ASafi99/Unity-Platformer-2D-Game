﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeApplication : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("escape")) Application.Quit();
    }

    public void quitGame(){
        Application.Quit();
    }
}
