using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVidaController : MonoBehaviour
{  

    public static PlayerVidaController instance;
    private void Awake() {
        instance = this;
    }
    public int currentHealth, maxHealt = 6;
    public float invencible = 1f;
    private float timeInvencible;
    private SpriteRenderer spriteRenderer;
    public GameObject deadEffect;
    
    void Start()
    {
        currentHealth = maxHealt;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if(timeInvencible > 0){
            timeInvencible -= Time.deltaTime;

            if(timeInvencible <= 0){
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b , 1f);
            }
        }
    }

    public void DealDamage(){
        if(timeInvencible <= 0){

          currentHealth --;
          PlayerCoontroller.instance.Ani.SetTrigger("Damage");
          AudioManager.instance.PlaySoundEffects(9);
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

    public void HealfPlayer(){
        currentHealth ++;

        if(currentHealth > maxHealt){
            currentHealth = maxHealt;
        }

        UIController.instance.UpdateHealtDisplay();
    }
}
