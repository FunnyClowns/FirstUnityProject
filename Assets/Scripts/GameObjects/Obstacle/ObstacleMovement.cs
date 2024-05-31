using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardSpeed;
    public GameObject chunk;
    public bool startMoving;

    // Special Obstacle

    // Rolling Obs
    public bool isRolling;
    private Vector3 RollingRotation = new Vector3(-100, 0, 0);

    // Bullet Obs
    public bool isBullet;
    private bool isCountdowned;
    private float bulletCountdownSpeed = -1f;
    private float bulletSpeed = -3500f;


    void FixedUpdate()
    {
        if(chunk.GetComponent<ChunkComponent>().startMoving){
            if (isRolling){
                Quaternion deltaRotation = Quaternion.Euler(RollingRotation * Time.fixedDeltaTime);
                rb.MoveRotation(rb.rotation * deltaRotation);
            }

            if(isBullet){
                if(!isCountdowned){
                    isCountdowned = true;
                    forwardSpeed = bulletCountdownSpeed;
                    Invoke("shootBullet", 1.5f);
                }
            }

            rb.AddForce(0, 0, forwardSpeed * Time.deltaTime);
        } else if (startMoving == true){
            rb.AddForce(0, 0, forwardSpeed * Time.deltaTime);
        }
    }
    
    private void shootBullet(){
        forwardSpeed = bulletSpeed;
    }
}
