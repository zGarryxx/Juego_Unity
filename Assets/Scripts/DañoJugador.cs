﻿using System.Collections;
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

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            PlayerVidaController.instance.DealDamage();
        }
    }
}
