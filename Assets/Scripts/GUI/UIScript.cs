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

    private String targetLoadScene;

    void Awake(){

        switch(SceneManager.GetActiveScene().name){
            case "Level01":
                targetLoadScene = "Level02";
                break;
            
            case "Level02":
                targetLoadScene = "Level03";
                break;

            case "Level03":
                break;

            default:
                Debug.Log("Error detecting active level.");
                break;

        }

        // Button
        btnReplay.onClick.AddListener(btnReplayClicked);

        btnNextLevel.onClick.AddListener(btnNextClicked);

        btnExitGame.onClick.AddListener(btnExitClicked);

    }

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
        StartCoroutine(showButtons(isGameWin));
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

    // --------Buttons--------

    // Show Button
    private IEnumerator showButtons(bool isGameWin){
        yield return new WaitForSeconds(2);

        if (isGameWin){
            btnNextLevel.gameObject.SetActive(true);    
        } else {
            btnReplay.gameObject.SetActive(true);
        }

        btnExitGame.gameObject.SetActive(true);
    }

    // --------Replay Button--------

    // Trigger when button is clicked
    private void btnReplayClicked(){
        bool isClicked = false;

        if(!isClicked){
            isClicked = true;
            StartCoroutine("replayGame");
        }
    }

    // Replay the game
    private IEnumerator replayGame(){
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // --------Next Button--------

    // Trigger when button is clicked
    private void btnNextClicked(){
        bool isClicked = false;

        if(!isClicked){
            isClicked = true;
            StartCoroutine("changeLevel");
        }
    }

    // Move player scene to Level02
    private IEnumerator changeLevel(){
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(targetLoadScene);
    }

    // --------Exit Button--------

    //Trigger when button is clicked
    private void btnExitClicked(){
        bool isClicked = false;

        if (!isClicked){
            isClicked = true;
            StartCoroutine("exitGame");
        }
    }

    private IEnumerator exitGame(){
        yield return new WaitForSeconds(2);

        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
