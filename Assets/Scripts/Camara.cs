using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
      
      public Transform target;
      public Transform bgfar, gbmidle;
      private Vector2 lastPos;
      public float minHight = -1.5f, maxHight = 2.5f;



    void Start()
    {
        lastPos = transform.position;
    }

   
    void Update()
    {
       // transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
       transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHight, maxHight), transform.position.z);

        Vector2 amountTomove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);;
        bgfar.position = bgfar.position + new Vector3(amountTomove.x, amountTomove.y, 0f);
        gbmidle.position += new Vector3(amountTomove.x , amountTomove.y, 0f) * .5f;
        lastPos = transform.position;
    }
}
