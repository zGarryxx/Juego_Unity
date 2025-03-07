using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{

  // Este metodo se encarga de verificar si el jugador entra en la zona de muerte
  private void OnTriggerEnter2D(Collider2D other) {
      if(other.tag == "Player"){
          
          LevelManager.instance.RespawnPlayer();
          
      }
  }
}
