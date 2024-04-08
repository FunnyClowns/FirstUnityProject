using System.Collections;
using UnityEngine;

public class SpawnFObstacle : MonoBehaviour
{
    public GameObject FObstacle;
    public GameObject posOffset;
    public GameManagerScript gameManager;

    private void Start(){
        StartCoroutine(spawnFObsLoop());
    }

    private IEnumerator spawnFObsLoop(){
        do {
            // Generate random Vector3 for various variations location
            Vector3 randomVectorPos = new Vector3 (Random.Range(-5, 5), 0, Random.Range(-5, 5));

            float randomWaitTime = Random.Range(11, 15);
            yield return new WaitForSeconds(randomWaitTime);

            // Duplicate flying objects
            GameObject DuplicateFObj = Instantiate(FObstacle);

            DuplicateFObj.transform.position = this.transform.position + randomVectorPos;
            DuplicateFObj.GetComponent<FObstacleMovement>().startMoving = true;
            DuplicateFObj.GetComponent<FObstacleMovement>().posOffset = posOffset;

        }while (!gameManager.GetGameEndedVal());
    }
}
