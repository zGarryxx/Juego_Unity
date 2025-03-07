using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartFisicas : MonoBehaviour
{

  // Estas variables son para saber si el jugador esta en el suelo
  public Transform Gr;
  public bool isGr;
  public LayerMask Ground;
  private Rigidbody2D rb;

  // En est caso el metodo Start se encarga de obtener el componente Rigidbody2D
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // En este caso el metodo Update se encarga de verificar si el jugador esta en el suelo
    void Update()
    {
         isGr = Physics2D.OverlapCircle(Gr.position, .2f, Ground);
         if (isGr){
          rb.linearVelocity = new Vector2(0,0);
          rb.gravityScale = 0;
          rb.mass = 0;
         }
    }
}
