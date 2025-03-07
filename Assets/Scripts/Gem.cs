using UnityEngine;

public class Gem : MonoBehaviour
{

    // Est metodo se encarga de recolectar las gemas
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GemCollector.CollectGem();
            Destroy(gameObject);
        }
    }
}