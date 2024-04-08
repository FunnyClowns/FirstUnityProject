using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTouch : MonoBehaviour
{
    
    void OnCollisionEnter(Collision touchInfo){
        if(touchInfo.collider.tag == "Obstacles"){
            Destroy(touchInfo.gameObject);
        } else if(touchInfo.collider.tag == "Player"){
            Destroy(this.gameObject);
        }
    }
}
