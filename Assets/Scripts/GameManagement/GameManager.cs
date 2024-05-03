using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject uiManager;
    public PlayerMovement player;

    public bool isGameEnded = false;
    private string currentLevel;

    void Start(){

        currentLevel = SceneManager.GetActiveScene().name;

        switch(currentLevel){
            case "Level01":
                Debug.Log("Level 01");
                SceneManager.CreateScene("Leve02");
                break;
            
            case "Level02":
                Debug.Log("Level 02");
                SceneManager.CreateScene("Leve03");
                break;

            case "Level03":
                Debug.Log("Level 03");
                break;
            
            default:
                Debug.Log("Failed loading scene");
                break;
        }
        
    }

    public void endGame(bool isGameWin){
        if(!isGameEnded){
            isGameEnded = true;

            if(isGameWin){
                Debug.Log("GAME WIN");
            } else {
                Debug.Log("GAME LOSE");
            }

            player.stopPlayerMovement();
            uiManager.GetComponent<UIScript>().endGame(isGameWin);
        }
    }
}
