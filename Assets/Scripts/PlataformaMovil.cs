using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
  private void OnCollisionEnter(Collision other) {
      if (other.transform.tag == "Player"){
        other.transform.parent = this.gameObject.transform.parent;
      }
  }
}
