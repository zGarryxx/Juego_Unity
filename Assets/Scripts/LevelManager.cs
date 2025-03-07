using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    // Estas variables son para el respawn del personaje
    public static LevelManager instance;
    private void Awake() {
        instance = this;
    }
    public float spawnTime = 2f;
    public int gemCollectect;

    void Start()
    {
        
    }

  
    void Update()
    {
        
    }

    // El metodo RespawnPlayer() se encarga de hacer reaparecer al jugador en el punto de control
    public void RespawnPlayer(){
      StartCoroutine(RespawnCO());
    }

    // El metodo RespawnCO() es un metodo que se encarga de hacer reaparecer al jugador en el punto de control
    IEnumerator RespawnCO(){

        PlayerCoontroller.instance.gameObject.SetActive(false);

       yield return new WaitForSeconds(spawnTime);

       PlayerCoontroller.instance.gameObject.SetActive(true);

       PlayerCoontroller.instance.transform.position = CheckpointController.instance.spawnPoint;
       
       PlayerVidaController.instance.currentHealth = PlayerVidaController.instance.maxHealt;

       UIController.instance.UpdateHealtDisplay();

    }
}
