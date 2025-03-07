using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{

    // lifeTime es el tiempo de vida del objeto
    public float lifeTime = 0.5f;

    // En este metodo update se destruye el objeto despues de un tiempo
       void Update()
    {
        Destroy(gameObject, lifeTime);
    }
}
