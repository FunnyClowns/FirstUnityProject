using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FObstacleMovement : MonoBehaviour
{

    public Rigidbody rb;
    public GameObject player;
    public GameObject posOffset;
    public Material FObsReadyMaterial;
    public bool startMoving = false;
    
    private bool stopLook = false;
    private bool isFObsReady = false;
    private Vector3 RollingRotation = new Vector3(0, 0, -50);
    private Vector3 tempPos; 
    Vector3 velocity;

    void Start(){
        tempPos = posOffset.transform.position;

    }

    void FixedUpdate(){
        if (startMoving){

            if (!stopLook){
                lookAtPlayer();
            } else {
                setBulletSpinning();
            }
            
            if (transform.position != tempPos){
                moveToTempPos();
            } else {
                setFObsReady();
            }
        }
    }

    private void moveToTempPos(){
        this.transform.position = Vector3.SmoothDamp(this.transform.position, tempPos, ref velocity, Time.deltaTime, 10f);
    }

    private void lookAtPlayer(){
        this.transform.LookAt(player.transform.position);

    }

    private void setBulletSpinning(){
        Quaternion deltaRotation = Quaternion.Euler(RollingRotation * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
        
    }

    private void setFObsReady(){
        if(!isFObsReady){
            isFObsReady = true;
            Debug.Log("FObs Ready");
            StartCoroutine(shootFObs());

        }
    }

    private IEnumerator shootFObs(){
        Vector3 playerPos;

        float shootTime = UnityEngine.Random.Range(5, 9);
        yield return new WaitForSeconds(shootTime);

        this.GetComponent<Renderer>().material = FObsReadyMaterial;
        stopLook = true;

        playerPos = player.transform.position;
        yield return new WaitForSeconds(1f);

        tempPos = playerPos;
    }
}
