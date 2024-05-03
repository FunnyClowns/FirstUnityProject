using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameManagerScript gameManager;
    public GameObject bullet;
    public GameObject cannon;

    void Start(){
        StartCoroutine(spawnBulletsLoop());
    }

    IEnumerator spawnBulletsLoop(){
        bool firstLoop = true;

        do{
            float waitTime;

            if (firstLoop){
                waitTime = Random.Range(5f,10f);
                firstLoop = false;
            } else {
                waitTime = Random.Range(10f, 15f);
            }

            yield return new WaitForSeconds(waitTime);

            GameObject duplicateBullet = Instantiate(bullet);
            duplicateBullet.transform.position = cannon.transform.position + new Vector3(0f, 0f, Random.Range(-6f, 6f));
            duplicateBullet.GetComponent<BulletMovement>().enabled = true;

        }while(!GameEnded());
    }

    bool GameEnded(){
        // Stop spawning if the game is ended
        return gameManager.isGameEnded;
    }
}
