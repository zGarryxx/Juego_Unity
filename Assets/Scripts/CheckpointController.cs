using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{

    public static CheckpointController instance;
    private void Awake() {
        instance = this;
    }

    private void Start(){
        checkpoints = FindObjectsOfType<Checkpoint>();
        spawnPoint = PlayerCoontroller.instance.transform.position;
    }
  public Checkpoint[] checkpoints;
  public Vector3 spawnPoint;

  public void DesactivateCheckpoint(){
      for(int i = 0; i< checkpoints.Length; i++){
          checkpoints[i].ResetCheckpoint();
      }
  }

  public void SetSpawnPoint( Vector3 newSpawnPoint){
     spawnPoint = newSpawnPoint;
  }


   
}
