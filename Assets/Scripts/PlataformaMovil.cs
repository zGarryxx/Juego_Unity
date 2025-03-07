using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{

  // OnColisionEnter se encarga de verificar si el jugador entra en la plataforma
  private void OnCollisionEnter(Collision other) {
      if (other.transform.tag == "Player"){
        other.transform.parent = this.gameObject.transform.parent;
      }
  }
}
