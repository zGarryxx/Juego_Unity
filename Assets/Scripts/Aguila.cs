using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaglePatyrullar : MonoBehaviour
{

   public float velocidadMove;
   public Transform[] puntoMove;
   public float distMin;
   private int numeroAleatorio;
   public SpriteRenderer spriteRenderer;

    // El metodo Start se encarga de inicializar el numero aleatorio y llamar al metodo Girar
   private void Start() {
     
       numeroAleatorio = Random.Range(0, puntoMove.Length);
     Girar();

     for( int i = 0; i< puntoMove.Length; i++){
      puntoMove[i].parent = null;
     }
   }

    // El metodo Update se encarga de mover el aguila
   private void Update() {
       transform.position = Vector2.MoveTowards(transform.position, puntoMove[numeroAleatorio].position, velocidadMove * Time.deltaTime);
       if(Vector2.Distance(transform.position, puntoMove[numeroAleatorio].position) < distMin){
         numeroAleatorio = Random.Range(0, puntoMove.Length);
         
         Girar();

       }
   }

    // El metodo Girar se encarga de girar el sprite del aguila
   private void Girar(){
       if(transform.position.x < puntoMove[numeroAleatorio].position.x){
           spriteRenderer.flipX = true;
       }else{
           spriteRenderer.flipX = false;
       }
   }
}
