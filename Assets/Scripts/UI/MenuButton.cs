using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class MenuButton : MonoBehaviour, IPointerClickHandler
{
    
    public bool nextLevelButton;
    public bool replayGameButton;
    public bool exitSceneButton;

    private bool isButtonClicked = false;

    public void OnPointerClick(PointerEventData pointerEvent){
        if (pointerEvent.button == PointerEventData.InputButton.Left && !isButtonClicked){
            isButtonClicked = true;

            if (nextLevelButton){
                Invoke("loadNextScene", 2f);
            } else if(replayGameButton){
                Invoke("loadCurrentScene", 2f);
            } else if(exitSceneButton){
                Invoke("exitScene", 2f);
            } else {
                Debug.Log("Error processing clicked button");
            }

        }
    }

    private void loadNextScene(){
        SceneManager.LoadScene(getNextScene());
    }

    private string getNextScene(){
        string nextScene = "";
        string activeScene = SceneManager.GetActiveScene().name;

        Debug.Log(activeScene);
        switch(activeScene){    

            case "Level01":
                nextScene = "Level02";
                break;
            
            case "Level02":
                nextScene = "Level03";
                break;

            case "Level03":
                nextScene = "MainMenu";
                break;

            default:
                Debug.Log("Error detecting active level.");
                break;

        }

        return nextScene;
    }

    private void loadCurrentScene(){
        SceneManager.LoadScene(getCurrentScene());
    }

    private string getCurrentScene(){
        return SceneManager.GetActiveScene().name;
    }

    private void exitScene(){
        SceneManager.LoadScene("MainMenu");
    }
}
