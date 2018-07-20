﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Canvas mainMenuCanvas;
    public Canvas creditsCanvas;


    private void Start()
    {
       
     
    }


    public void onStartClicked()
    {
        SceneManager.LoadSceneAsync("MainLevel");
    }

    public void onCreditsClicked()
    {
        creditsCanvas.enabled = true;
        mainMenuCanvas.enabled = false;


    }

    public void onBackButtonClicked()
    {
        creditsCanvas.enabled = false;
        mainMenuCanvas.enabled = true;
    }

    public void onQuitClicked()
    {
        Application.Quit();
    }
    
    

}