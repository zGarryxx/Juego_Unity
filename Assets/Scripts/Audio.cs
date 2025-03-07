using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    private void Awake() {
        instance = this;
    }

    public AudioSource[] soundEfect;
    public AudioSource backGround, levelend;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    // PlaySoundEffects reproduce el sonido de los efectos de sonido
    public void PlaySoundEffects(int sountToPlay){

        soundEfect[sountToPlay].Stop();

        soundEfect[sountToPlay].pitch = Random.Range(.9f,1.1f);

       soundEfect[sountToPlay].Play();
    }
}
