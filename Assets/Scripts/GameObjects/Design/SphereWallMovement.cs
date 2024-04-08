using System;
using System.Collections;
using UnityEngine;

public class SphereWallMovement: MonoBehaviour
{
    private float frequency;
    private Vector3 posOffset = new Vector3();
    private Vector3 tempPos = new Vector3();

     void Start(){
          posOffset = this.gameObject.transform.position;

          float randomFreq = UnityEngine.Random.value;

          frequency = randomFreq;
        
   }

     void FixedUpdate(){
          tempPos = posOffset;
          tempPos.y += MathF.Sin(Time.fixedTime * Mathf.PI * frequency) * 0.3f;

          this.gameObject.transform.position = tempPos;

   }
}
