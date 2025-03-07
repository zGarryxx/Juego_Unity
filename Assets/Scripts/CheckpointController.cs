using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{

    public static CheckpointController instance;
    private void Awake() {
        instance = this;
    }

    // El metodo Start en este caso se encarga de buscar los checkpoints y establecer el punto de spawn
    private void Start(){
        checkpoints = FindObjectsOfType<Checkpoint>();
        spawnPoint = PlayerCoontroller.instance.transform.position;
    }

  public Checkpoint[] checkpoints;
  public Vector3 spawnPoint;

    // DesactivateCheckpoint se encarga de desactivar el checkpoint
  public void DesactivateCheckpoint(){
      for(int i = 0; i< checkpoints.Length; i++){
          checkpoints[i].ResetCheckpoint();
      }
  }

    // SetSpawnPoint se encarga de establecer el punto de spawn
  public void SetSpawnPoint( Vector3 newSpawnPoint){
     spawnPoint = newSpawnPoint;
  }


   
}
