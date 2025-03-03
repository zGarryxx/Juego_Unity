using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public bool isGem , isHeart;
    
    private bool isCollectect;
    public GameObject efectCollect;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            if(isGem){

                LevelManager.instance.gemCollectect++;

                UIController.instance.UpdateGemCount();

                Instantiate(efectCollect, transform.position, transform.rotation);

                AudioManager.instance.PlaySoundEffects(6);

                isCollectect = true;

                Destroy(gameObject);



            }

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
