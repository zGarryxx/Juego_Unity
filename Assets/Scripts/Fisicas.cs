using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartFisicas : MonoBehaviour
{
  public Transform Gr;
  public bool isGr;
  public LayerMask Ground;
  private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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
