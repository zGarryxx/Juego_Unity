using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{

    
  
    void Start()
    {
        
    }

  
    void Update()
    {
        
    }

    // OnTriggerEnter2D se llama cuando otro objeto entra en un objeto con Collider2D
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            PlayerVidaController.instance.DealDamage();
        }
    }
}
