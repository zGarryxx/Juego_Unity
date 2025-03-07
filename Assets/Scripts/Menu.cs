using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string StartScene;

    // StartGame y QuitGame son metodos que se encargan de iniciar el juego y cerrar el juego respectivamente
    
    public void StartGame(){
        SceneManager.LoadScene(StartScene);
    }

    public void QuitGame(){
        Application.Quit();
    }
  
}
