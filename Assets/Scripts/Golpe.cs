using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchBox : MonoBehaviour
{
  
    [Range(0,100)] public float chanseToDrop ;
    public GameObject collectible;
    
    public GameObject deadEffect;
    public Vector3 v3 = new Vector3(1,0.4f,0);
  private void OnTriggerEnter2D(Collider2D other) {
      if(other.tag == "Enemy"){
         other.transform.parent.gameObject.SetActive(false);
         
         Instantiate(deadEffect, other.transform.position, other.transform.rotation);
         PlayerCoontroller.instance.Bounce();

         float dropSelectect = Random.Range(0,100);

         if(dropSelectect <= chanseToDrop){
             Instantiate(collectible, other.transform.position + v3, other.transform.rotation);
            
         }
         
         AudioManager.instance.PlaySoundEffects(3);

      }
  }
}
