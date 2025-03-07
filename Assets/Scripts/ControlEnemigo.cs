using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    // Las variables publicas se pueden modificar desde el inspector de Unity
    public float movSpeed = 3f;
    public Transform leftPoint,rigthPoint;
    private bool movingRight;
    private Rigidbody2D rb;
    public SpriteRenderer SR;
    public float moveTime = 3f, waitTime = 2f;
    private float moveCount, waitCount;
    public Animator animator;
    
    // Start se llama antes de la primera actualización del frame
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        leftPoint.parent = null;
        rigthPoint.parent = null;

        movingRight = true;

        moveCount = moveTime;
    }

   // El metodo Update aqui lo que hace es mover al enemigo de un punto a otro
    void Update()
    {
        if(moveCount > 0){

            animator.SetBool("isMoving", true);
           
           moveCount -= Time.deltaTime;

           if(movingRight){

            rb.linearVelocity = new Vector2(movSpeed, rb.linearVelocity.y);
            SR.flipX = true;

            if(transform.position.x > rigthPoint.position.x){
                movingRight = false;
            }
        }else{
             rb.linearVelocity = new Vector2(-movSpeed, rb.linearVelocity.y);
            SR.flipX = false;

            
            if(transform.position.x < leftPoint.position.x){
                movingRight = true;
            }
        }
        if(moveCount <= 0){
            waitCount = Random.Range(waitTime * .75f, waitTime * 1.25f);
        }

        

    // Si el enemigo no se mueve, entonces se detiene
    }else if(waitCount > 0){

         animator.SetBool("isMoving", false);
        waitCount -= Time.deltaTime;
        rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);

        if(waitCount <= 0){
            moveCount = Random.Range(moveTime * .75f, waitTime * 1.25f);
        }
    }
}
       
}
