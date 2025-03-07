using UnityEngine;

public class GemCollector : MonoBehaviour
{
    // Estas variables son para contar las gemas recolectadas
    private static int collectedGems = 0;
    private const int totalGems = 29; 

    // Aqui start se emplea para iniciar el juego
    private void Start()
    {
        collectedGems = 0;
    }

    // Este metodo se encarga de recolectar las gemas
    public static void CollectGem()
    {
        collectedGems++;
    }

    // Este metodo se encarga de verificar si se han recolectado todas las gemas
    public static bool AllGemsCollected()
    {
        return collectedGems >= totalGems;
    }
}