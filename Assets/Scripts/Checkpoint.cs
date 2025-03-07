using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public SpriteRenderer SR;
    public Sprite CPon , CPoff;

   
// OnTriggerEnter2D se llama cuando otro objeto entra en un objeto con Collider2D
private void OnTriggerEnter2D(Collider2D other) {
    if(other.tag == "Player"){
        CheckpointController.instance.DesactivateCheckpoint();
        SR.sprite = CPon;
        CheckpointController.instance.SetSpawnPoint(transform.position);
    }
}

// ResetCheckpoint se encarga de resetear el checkpoint
public void ResetCheckpoint(){
    SR.sprite = CPoff;
}

}
