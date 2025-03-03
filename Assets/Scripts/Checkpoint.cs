using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public SpriteRenderer SR;
    public Sprite CPon , CPoff;

   
private void OnTriggerEnter2D(Collider2D other) {
    if(other.tag == "Player"){
        CheckpointController.instance.DesactivateCheckpoint();
        SR.sprite = CPon;
        CheckpointController.instance.SetSpawnPoint(transform.position);
    }
}

public void ResetCheckpoint(){
    SR.sprite = CPoff;
}

}
