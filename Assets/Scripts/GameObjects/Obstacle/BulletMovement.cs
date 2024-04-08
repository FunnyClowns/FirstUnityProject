using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public GameObject player;
    private bool startMoving = false;
    private int MovementPhrase = 0;
    private Vector3 tempPos;
    private bool continueMoving = true;
    private Vector3 velocity;

    void Start(){
        StartCoroutine(MoveToNextPhrase());
    }

    void FixedUpdate(){
        if (startMoving){
            this.transform.position = Vector3.SmoothDamp(this.transform.position, tempPos, ref velocity, Time.deltaTime, 20f );
        }
    }

    IEnumerator MoveToNextPhrase(){

        do{
            float waitTime = Random.Range(1f, 1.5f);
            MovementPhrase += 1;
            startMoving = false;

            yield return new WaitForSeconds(waitTime);

            startMoving = true;

            switch(MovementPhrase){
                case 1:
                    // First movement
                    Debug.Log("First movement");
                    tempPos = new Vector3(Random.Range(-6, 6f), Random.Range(18f, 20.4f), Random.Range(41.7f, 43.7f));

                    break;

                case 5:
                    // Fifth movement
                    Debug.Log("Move to player");
                    MoveToPlayer();
                    continueMoving = false;
                    
                    break; 

                default:
                    Debug.Log("Other cases");

                    tempPos = new Vector3(Random.Range(-6f, 6f), tempPos.y - Random.Range(2f, 4f), tempPos.z - Random.Range(8f, 10f));
                    break;
            }

            // Generate next input to chooses between moving to player or moving to next phrase
            float rng = Random.value;

            if (continueMoving){
                if (rng <= 0.9f){
                    Debug.Log("Move again");
                } else {
                    Debug.Log("Move to player");
                    MoveToPlayer();
                    continueMoving = false;
                }
            }

            yield return new WaitForSeconds(waitTime);

        }while(continueMoving);
    }

    void MoveToPlayer(){
        Vector3 playerPos;
        
        Debug.Log(tempPos);
        playerPos = player.transform.position;
        tempPos = playerPos;

        Debug.Log(tempPos);
    }
}
