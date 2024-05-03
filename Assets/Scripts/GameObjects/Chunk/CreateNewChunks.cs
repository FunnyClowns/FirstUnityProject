using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreateNewChunks : MonoBehaviour
{

    [SerializeField] GameManagerScript gameManager;
    
    [SerializeField] GameObject[] Chunks;
    

    void Start(){ StartCoroutine(GenerateNewChunk()); }

    GameObject getRandomChunk(int chunksLength){
        int randomChunk = Random.Range(0, chunksLength);

        Debug.Log(randomChunk + 1);

        return Chunks[randomChunk];
    }


    private readonly float WaitTime = 3f;

    IEnumerator GenerateNewChunk(){
        int chunksLength = Chunks.Length;

        do{

            yield return new WaitForSeconds(WaitTime);

            GameObject Duplicate = Instantiate(getRandomChunk(chunksLength));

            Duplicate.transform.position = this.gameObject.transform.position;
            Duplicate.GetComponent<ChunkComponent>().startMoving = true;
            
        } while(!GameEnded());
    }

    bool GameEnded(){
        // Stop spawning if the game is ended
        return gameManager.isGameEnded;
    }
}
