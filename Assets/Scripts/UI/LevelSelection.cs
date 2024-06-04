using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public bool isLocked = true;

    [SerializeField] string LevelScene; 
    [SerializeField] GameObject LevelText;
    [SerializeField] GameObject LockedText;

     public void OnClickButton(){
          if(!isLocked){
               SceneManager.LoadScene(LevelScene);
          }
     }

     public void UnlockLevel(){
          isLocked = false;

          LevelText.SetActive(true);
          LockedText.SetActive(false);
     }

     public void LockLevel(){
          isLocked = true;

          LevelText.SetActive(false);
          LockedText.SetActive(true);
     }
}
