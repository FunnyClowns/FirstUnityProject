using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour{

    private int Score = -1;
    public TextMeshProUGUI scoreText;
    public bool isWin = false;
    public bool timeStopped = false;
    public GameManagerScript gameManager;
    
    void Start()
    {
        scoreText.text = Score.ToString();
        
        StartCoroutine(CountScore());
    }

    IEnumerator CountScore(){
        do{
            if(Score == 60){
                gameManager.endGame(true);
                isWin = true;
            } else if (Score < 60 && !timeStopped) {
                Score++;
                scoreText.text = Score.ToString();  
            } else if (timeStopped) {
                Debug.Log("Time Stopped");
            } else {
                Debug.Log("Error countings score");
            }

            yield return new WaitForSeconds(1f);
            
            
        } while(!isWin);
    }

    public int getScore(){
        return Score;
    }
}
