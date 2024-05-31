using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject uiManager;
    public PlayerMovement player;
    [SerializeField] GameDataManager gameDataManager;

    public bool isGameEnded = false;
    private string activeScene;

    void Start(){
        activeScene = SceneManager.GetActiveScene().name;   
    }

    public void endGame(bool isGameWin){
        if(!isGameEnded){
            isGameEnded = true;

            if(isGameWin){
                Debug.Log("GAME WIN");

                gameDataManager.SaveLevel(activeScene);

            } else {
                Debug.Log("GAME LOSE");
            }

            player.stopPlayerMovement();
            uiManager.GetComponent<UIScript>().endGame(isGameWin);
        }
    }
}
