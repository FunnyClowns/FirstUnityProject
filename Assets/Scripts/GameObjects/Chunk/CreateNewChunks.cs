using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreateNewChunks : MonoBehaviour
{
    private float WaitTime = 3f;

    public GameManagerScript gameManager;
    
    public GameObject[] Chunks;
    

    void Start()
    {
        StartCoroutine(GenerateNewChunk());
    }

    GameObject getRandomChunk(int chunksLength){
        int randomChunk = Random.Range(0, chunksLength);

        Debug.Log(randomChunk + 1);

        return Chunks[randomChunk];
    }

    IEnumerator GenerateNewChunk(){
        int chunksLength = Chunks.Length;

        do{

            yield return new WaitForSeconds(WaitTime);

            GameObject Duplicate = Instantiate(getRandomChunk(chunksLength));

            Duplicate.transform.position = this.gameObject.transform.position;
            Duplicate.GetComponent<ChunkComponent>().startMoving = true;
            
        } while(!gameManager.GetGameEndedVal());
    }
}
