using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    // Estas variables son para que se pueda acceder a ellas desde cualquier parte del codigo
    public static UIController instance;
    public Image Heart1 , Heart2, Heart3;
    public Sprite HeartFull, HeartHalf , HeartEmpty;
    public Text gemText;

    private void Awake() {
        instance = this;
    }
    
    // Start se encarga de inicializar las variables
    void Start()
    {
        UpdateGemCount();
    }

    void Update()
    {
        
    }

    // Este metodo se encarga de actualizar la vida del jugador
    public void UpdateHealtDisplay(){
        switch(PlayerVidaController.instance.currentHealth){
            case 6:
                   Heart1.sprite = HeartFull;
                   Heart2.sprite = HeartFull;
                   Heart3.sprite = HeartFull; 
                   break;
             case 5:
                   Heart1.sprite = HeartFull;
                   Heart2.sprite = HeartFull;
                   Heart3.sprite = HeartHalf; 
                   break;
            case 4:
                   Heart1.sprite = HeartFull;
                   Heart2.sprite = HeartFull;
                   Heart3.sprite = HeartEmpty; 
                   break;
            case 3:
                   Heart1.sprite = HeartFull;
                   Heart2.sprite = HeartHalf;
                   Heart3.sprite = HeartEmpty; 
                   break;
            case 2:
                   Heart1.sprite = HeartFull;
                   Heart2.sprite = HeartEmpty;
                   Heart3.sprite = HeartEmpty; 
                   break;
            case 1:
                   Heart1.sprite = HeartHalf;
                   Heart2.sprite = HeartEmpty;
                   Heart3.sprite = HeartEmpty; 
                   break;

            case 0:
                   Heart1.sprite = HeartEmpty;
                   Heart2.sprite = HeartEmpty;
                   Heart3.sprite = HeartEmpty; 
                   break;

            default: 
                   Heart1.sprite = HeartEmpty;
                   Heart2.sprite = HeartEmpty;
                   Heart3.sprite = HeartEmpty; 
                   break;



        }
    }

    // Este metodo se encarga de actualizar la cantidad de gemas que ha recolectado el jugador
    public void UpdateGemCount(){
           gemText.text = LevelManager.instance.gemCollectect.ToString();
    }


}
