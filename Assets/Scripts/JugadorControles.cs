using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerCoontroller : MonoBehaviour
{

    public static PlayerCoontroller instance;

    private void Awake() {
        instance = this;
    }

    private float moveSpeed;
    public float speed = 5f;
    private float moveSpeedCrouch ;
    public Rigidbody2D rb;
    public FloatingJoystick Joy;
    public bool movile = true;
    public float jumpForce = 25f;
    public bool canJumpOrray = true;
    public Transform groundCheckpoint;
    public LayerMask Ground;
    public bool isGrounded;
    public bool crouch = false;
    public Animator Ani;
    private SpriteRenderer spriteR;
    public float knockBackLenght = .25f, knockBackForce = 2f;
    private float knockBackCounter;
    public float bounceForce = 3f;
    public float escalaGravedad;
    public bool botonSaltarArriba = true;
    [Range(0,1)] [SerializeField] private float multiplicadorCancelarSalto;
    [SerializeField] private float multiplicadorGHravedad;
    
    void Start()
    {
        escalaGravedad = rb.gravityScale;
        spriteR = GetComponent<SpriteRenderer>();
        moveSpeedCrouch = speed * 0.5f;
        moveSpeed = speed;
    }


    void Update()
    {
   

       if(Input.GetKeyDown(KeyCode.LeftControl) || CrossPlatformInputManager.GetButtonDown("Crouch")){
         if(!crouch){
             crouch = true;

         }else if( crouch){
             crouch = false;
         }
           Crouch();
       }
        
/////////////////////////////////////////////////////////////////////////
       

         isGrounded = Physics2D.OverlapCircle(groundCheckpoint.position, .2f, Ground);
         
         if(rb.linearVelocity.y < 0.1f && !isGrounded){
             Ani.SetBool("falling", true);
             canJumpOrray = false;
            
         }
         else if(/*rb.velocity.y >= -0.5f*/ isGrounded){
              Ani.SetBool("falling", false);
         }

         
      
       
    }
    private void FixedUpdate() {

          if( knockBackCounter <= 0){
             MoverPersonaje();
         }else{
             knockBackCounter -= Time.deltaTime;
            if(!spriteR.flipX){
                rb.linearVelocity = new Vector2( -knockBackForce, rb.linearVelocity.y);
            }else{
                 rb.linearVelocity = new Vector2( knockBackForce, rb.linearVelocity.y);
            }
         }

        if(Input.GetButton("Jump") || CrossPlatformInputManager.GetButton("Jump") && botonSaltarArriba) {
         
        Jump();
      

       }
       if(Input.GetButtonUp("Jump") || CrossPlatformInputManager.GetButtonUp("Jump")){
        BotonSaltoArriba();
        canJumpOrray = true;
       }

        if(rb.linearVelocity.y < 0 && !isGrounded){
            rb.gravityScale = escalaGravedad * multiplicadorGHravedad;
        }else{
            rb.gravityScale = escalaGravedad;
        }
    }

    public void MoverPersonaje(){
       if(movile){
       rb.linearVelocity = new Vector2(Joy.Direction.x * moveSpeed, rb.linearVelocity.y);
        }else 
         rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.linearVelocity.y);

       

       if(rb.linearVelocity.x < 0)
       {
           spriteR.flipX = true;
        }else if(rb.linearVelocity.x > 0){
         spriteR.flipX = false;
      }       
       Ani.SetFloat("moveSpeed", Mathf.Abs(rb.linearVelocity.x));
       Ani.SetBool("isGrounded", isGrounded);

    }

    public void Jump(){
         if(isGrounded /*&& canJumpOrray*/)
         {
             rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
           AudioManager.instance.PlaySoundEffects(10);
           
           }
           botonSaltarArriba = false;
    }

    public void Crouch(){


        if(crouch){
            Ani.SetBool("crouch", true);
            moveSpeed = moveSpeedCrouch;
        }
        if(!crouch){
        Ani.SetBool("crouch", false);
        moveSpeed = speed;
        }
    }

    private void BotonSaltoArriba(){
        if(rb.linearVelocity.y > 0){
            rb.AddForce(Vector2.down * rb.linearVelocity.y * (1-multiplicadorCancelarSalto), ForceMode2D.Impulse);

        }
        
        botonSaltarArriba = true;
    }
    public void KnockBack(){
       knockBackCounter = knockBackLenght;
       rb.linearVelocity = new Vector2(0f, knockBackForce);
    }

    public void Bounce (){
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceForce);
    }

}
