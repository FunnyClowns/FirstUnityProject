using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameManagerScript gameManager;
    public GameObject bullet;
    public GameObject cannon;


    private char cannonType;

    void Start(){
        checkCannonPosLR();
        StartCoroutine(spawnBulletsLoop());
    }

    // Check if cannon pos is Left or Right
    void checkCannonPosLR(){
        switch(this.transform.parent.name){
            case "CannonM":
                cannonType = 'M';
                break;

            case "CannonL":
                cannonType = 'L';
                break;

            case "CannonR":
                cannonType = 'R';
                break;

            default:
                Debug.Log("Error checking cannon pos is Left Right");
                break;
        }
    }

    IEnumerator spawnBulletsLoop(){
        bool firstLoop = true;

        do{
            float waitTime;

            if (firstLoop && cannonType != 'M'){
                waitTime = Random.Range(1f, 3f);
                firstLoop = false;

            } else if (firstLoop && cannonType == 'M'){
                waitTime = Random.Range(5f, 10f);
                firstLoop = false;

            } else if (cannonType == 'M') {
                waitTime = Random.Range(10f, 15f);
            } else {
                waitTime = Random.Range(5f, 10f);
            }

            yield return new WaitForSeconds(waitTime);

            GameObject duplicateBullet = Instantiate(bullet);
            duplicateBullet.transform.position = cannon.transform.position + new Vector3(0f, 0f, Random.Range(-6f, 6f));

            if (cannonType != 'M'){
                duplicateBullet.GetComponent<BulletDMovement>().setTempPos(cannonType);
                duplicateBullet.GetComponent<BulletDMovement>().startMoving = true;
            } else {
                duplicateBullet.GetComponent<BulletMovement>().enabled = true;
            }

        }while(!GameEnded());
    }

    bool GameEnded(){
        // Stop spawning if the game is ended
        return gameManager.isGameEnded;
    }
}
