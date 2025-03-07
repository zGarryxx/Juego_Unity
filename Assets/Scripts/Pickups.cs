using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{

    // Estas variables son para los pickups
    public bool isGem , isHeart;
    private bool isCollectect;
    public GameObject efectCollect;

    // OnTriggerEnter2D se encarga de verificar si el jugador entra en contacto con el pickup
    private void OnTriggerEnter2D(Collider2D other) {

        // Si el jugador entra en contacto con el pickup, se verifica si es una gema o un corazon
        if(other.tag == "Player"){
            if(isGem){

                LevelManager.instance.gemCollectect++;

                UIController.instance.UpdateGemCount();

                Instantiate(efectCollect, transform.position, transform.rotation);

                AudioManager.instance.PlaySoundEffects(6);

                isCollectect = true;

                Destroy(gameObject);

            }

            // Si el jugador entra en contacto con el pickup, se verifica si es una gema o un corazon
            if(isHeart){
                if(PlayerVidaController.instance.currentHealth != PlayerVidaController.instance.maxHealt){
                    PlayerVidaController.instance.HealfPlayer();

                    AudioManager.instance.PlaySoundEffects(7);

                    isCollectect = true;
                    Destroy(gameObject);
                }
            }
        }
    }
}
