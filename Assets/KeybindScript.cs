using System.Collections;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeybindScript : MonoBehaviour
{
    
    bool isPressed;

    void Update(){

        if (Input.GetKeyDown(KeyCode.Escape)){
            if (!isPressed){
                isPressed = true;
                ChangeSceneToMenu();

                StartCoroutine(nameof(CountdownNextEvent));
            }

        }
        
    }

    void ChangeSceneToMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator CountdownNextEvent(){
        yield return new WaitForSeconds(10f);

        isPressed = false;
    }
}
