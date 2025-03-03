using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

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

    public void RespawnPlayer(){
      StartCoroutine(RespawnCO());
    }

    IEnumerator RespawnCO(){

        PlayerCoontroller.instance.gameObject.SetActive(false);

       yield return new WaitForSeconds(spawnTime);

       PlayerCoontroller.instance.gameObject.SetActive(true);

       PlayerCoontroller.instance.transform.position = CheckpointController.instance.spawnPoint;
       
       PlayerVidaController.instance.currentHealth = PlayerVidaController.instance.maxHealt;

       UIController.instance.UpdateHealtDisplay();

    }
}
