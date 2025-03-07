using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Esta variable nos permitirá saber si el juego está pausado o no
    private bool isPaused = false;

    // Update aqui se encarga de detectar si se presionó la tecla Escape
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Este método se encargan de pausar el juego
    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        Debug.Log("Juego pausado");
    }

    // Este método se encarga de reanudar el juego
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        Debug.Log("Juego reanudado");
    }
}