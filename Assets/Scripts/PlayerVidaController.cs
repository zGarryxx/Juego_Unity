using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVidaController : MonoBehaviour
{  

    // Estas variables son para que el jugador tenga una vida y se pueda morir
    public static PlayerVidaController instance;
    private void Awake() {
        instance = this;
    }
    public int currentHealth, maxHealt = 6;
    public float invencible = 1f;
    private float timeInvencible;
    private SpriteRenderer spriteRenderer;
    public GameObject deadEffect;
    
    // Start se llama antes de la primera actualización del marco
    void Start()
    {
        currentHealth = maxHealt;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Update aqui se llama una vez por fotograma y se encarga de actualizar la lógica del juego
    void Update()
    {
        if(timeInvencible > 0){
            timeInvencible -= Time.deltaTime;

            if(timeInvencible <= 0){
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b , 1f);
            }
        }
    }

    // Esta función se encarga de quitarle vida al jugador
    public void DealDamage(){

        // Si el tiempo invencible es menor o igual a 0, entonces
        if(timeInvencible <= 0){

          currentHealth --;
          PlayerCoontroller.instance.Ani.SetTrigger("Damage");
          AudioManager.instance.PlaySoundEffects(9);

        //  Si la vida del jugador es menor o igual a 0, entonces se activa la animación de muerte y se llama a la función RespawnPlayer
        if(currentHealth <= 0){

            currentHealth = 0;
            Instantiate(deadEffect, PlayerCoontroller.instance.transform.position, PlayerCoontroller.instance.transform.rotation);
             
            AudioManager.instance.PlaySoundEffects(8);

          LevelManager.instance.RespawnPlayer();
        }
       else {
           timeInvencible = invencible;
           spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b , .5f);
           PlayerCoontroller.instance.KnockBack();
       }
        }
         UIController.instance.UpdateHealtDisplay();
      
    }

    // Esta función se encarga de curar al jugador
    public void HealfPlayer(){
        currentHealth ++;

        if(currentHealth > maxHealt){
            currentHealth = maxHealt;
        }

        UIController.instance.UpdateHealtDisplay();
    }
}
