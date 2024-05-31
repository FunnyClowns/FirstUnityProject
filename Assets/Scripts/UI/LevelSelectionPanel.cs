using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionPanel : MonoBehaviour
{

    [SerializeField] GameDataManager gameDataManager;
    [SerializeField] UI_MenuCanvas MenuCanvas;
    [SerializeField] LevelSelection level01;
    [SerializeField] LevelSelection level02;
    [SerializeField] LevelSelection level03;
    GameData gameData;

    void Start(){
        gameData = gameDataManager.gameData;

        CheckLevelLock();
    }
    
    public void CheckLevelLock(){
        gameData = gameDataManager.gameData;

        if(gameData.Level01){
            level01.UnlockLevel();
        } else {
            level01.LockLevel();
        }

       if(gameData.Level02){
            level02.UnlockLevel();
        } else {
            level02.LockLevel();
        }

        if(gameData.Level03){
            level03.UnlockLevel();
        } else {
            level03.LockLevel();
        }
    }

    /// <summary>
    /// Called directly by the quit button in the UI prefab
    /// </summary>
    public void OnClickBackButton(){
        MenuCanvas.StartCoroutine("SwitchPanel");
    }

    /// <summary>
    /// Called directly by the quit button in the UI prefab
    /// </summary>
    public void OnClickDeleteButton(){
        gameDataManager.ResetData();
        CheckLevelLock();

    }

}
