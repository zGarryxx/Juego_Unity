using UnityEngine;
using UnityEngine.SceneManagement;

public class Meta : MonoBehaviour
{

    // Este metodo se encarga de reiniciar la escena cuando el jugador llega a la meta
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si el jugador llega a la meta y ha recolectado todas las gemas
        if (other.CompareTag("Player") && GemCollector.AllGemsCollected())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}