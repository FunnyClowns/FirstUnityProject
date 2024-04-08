using System;
using System.Collections;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    private float frequency;
    private Vector3 posOffset = new Vector3();
    private Vector3 tempPos = new Vector3();

   void Start(){
        posOffset = this.gameObject.transform.position;

        float randomFreq = UnityEngine.Random.Range(0.1f, 0.5f);

        frequency = randomFreq;
        
   }

   void FixedUpdate(){
    tempPos = posOffset;
    tempPos.y += MathF.Sin(Time.fixedTime * Mathf.PI * frequency) * 0.5f;

    this.gameObject.transform.position = tempPos;

   }
}
