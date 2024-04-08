using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChunkComponent : MonoBehaviour
{
    public bool startMoving = false;
    private GameObject Obstacle;


    void Start(){
        Obstacle = this.transform.Find("LastObstacle").gameObject;
    }

    void Update(){
        if (Obstacle.IsDestroyed() == true){
            Destroy(this. gameObject);
        }
    }
}
