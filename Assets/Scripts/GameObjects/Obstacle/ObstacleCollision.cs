using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision){
        if(collision.collider.tag == "Ground" || collision.collider.tag == "Obstacles" || collision.collider.tag == "Player"){
            Destroy(this.gameObject);
        }
    }
}
