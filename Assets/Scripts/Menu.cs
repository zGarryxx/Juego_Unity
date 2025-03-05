﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string StartScene;

    public void StartGame(){
        SceneManager.LoadScene(StartScene);
    }

    public void QuitGame(){
        Application.Quit();
    }
  
}
