using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using System;

public class UIScript : MonoBehaviour
{
    public Button btnReplay;
    public Button btnNextLevel;
    public Button btnExitGame;
    public TextMeshProUGUI txtScore;
    public TextMeshProUGUI txtGameStat;
    public TextMeshProUGUI txtScoreGameStat;
    public TextMeshProUGUI txtQuotes;
    

    public void endGame(bool isGameWin){
        txtScore.enabled = false;
        txtGameStat.gameObject.SetActive(true);
        txtQuotes.gameObject.SetActive(true);

        if(isGameWin){
            txtGameStat.text = "YOU WIN!";
        } else {
            txtGameStat.text = "YOU LOSE!";
            txtScoreGameStat.GetComponent<GetScore>().GameLose();
        }

        txtQuotes.GetComponent<RandomQuotes>().getRandomQuotes();
        StartCoroutine(showMenuButtons(isGameWin));
    }

    public void GameWin(){
        txtScore.enabled = false;
        txtGameStat.gameObject.SetActive(true);
        txtGameStat.text = "YOU WIN!";
    }

    public void GameLose(){
        txtScore.enabled = false;
        txtGameStat.gameObject.SetActive(true);
        txtScoreGameStat.GetComponent<GetScore>().GameLose();
        txtGameStat.text = "YOU LOSE!";
    }


    // Show Buttons
    private IEnumerator showMenuButtons(bool isGameWin){
        yield return new WaitForSeconds(2);

        if (isGameWin){
            btnNextLevel.gameObject.SetActive(true);    
        } else {
            btnReplay.gameObject.SetActive(true);
        }

        btnExitGame.gameObject.SetActive(true);
    }

}
