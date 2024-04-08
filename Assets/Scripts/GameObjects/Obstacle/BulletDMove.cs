using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BulletDMovement : MonoBehaviour
{
    public GameObject player;
    public bool startMoving = false;
    private Vector3 tempPos;
    private int MovementPhrase = 0;
    Vector3 velocity;

    public void setTempPos(char cannonType){
        
        switch(cannonType){
            case 'M':
                StartCoroutine(MoveToNextPhrase());

                break;

            case 'L':
                tempPos = new Vector3(Random.Range(-20f, -6f), -20f, Random.Range(0, 70f));
                break;

            case 'R':
                tempPos = new Vector3(Random.Range(6f, 20f), -20f, Random.Range(0, 70f));
                break;

            default:
                Debug.Log("Error setting tempPos");
                break;
        }

    }

    void FixedUpdate(){
        if(startMoving){
            this.transform.position = Vector3.SmoothDamp(this.transform.position, tempPos, ref velocity, Time.deltaTime, 20f );
            if (this.transform.position.y == -20f){
                Destroy(this.gameObject);
            }
        }
    }

    IEnumerator MoveToNextPhrase(){
        float waitTime = Random.Range(2f, 5f);
        MovementPhrase =+ 1;
        startMoving = true;

        switch(MovementPhrase){
            case 1:
                // First movement
                Debug.Log("First movement");

                break;

            case 2:
                // Second movement
                Debug.Log("Second movement");

                break;

            case 3:
                // Third movement
                Debug.Log("Third movement");

                break;

            case 4:
                // Fourth movement
                Debug.Log("Fourth movement");

                break;

            default:
                Debug.Log("Error moving bullet to next phase");

                break;
        }

        yield return new WaitForSeconds(waitTime);

        startMoving = false;
        // Generate next input to chooses between moving to player or moving to next phrase
        if (Random.value < 0.5){
            Debug.Log("Move again");
            MoveToNextPhrase();
        } else {
            Debug.Log("Move to player");
            MoveToPlayer();
        }
    }

    void MoveToPlayer(){

    }
}
