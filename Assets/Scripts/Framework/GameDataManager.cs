using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    string SaveFile;
    string FileContents;
    string jsonString;

    

    public GameData gameData = new GameData();

    void Awake(){
        SaveFile = Application.persistentDataPath + "/gameData.json";

        ReadFile();

        WriteFile();
        Debug.Log(FileContents);
    }

    void ReadFile(){
        if(System.IO.File.Exists(SaveFile)){
            // File does exit

            FileContents = System.IO.File.ReadAllText(SaveFile);

            gameData = JsonUtility.FromJson<GameData>(FileContents);
            
        }
    }

    void WriteFile(){
        
        // make sure level 01 is always unlocked
        gameData.Level01 = true;

        jsonString = JsonUtility.ToJson(gameData);

        System.IO.File.WriteAllText(SaveFile, jsonString);
    }

    public void ResetData(){
        gameData = new GameData();

        WriteFile();
        ReadFile();

        Debug.Log(FileContents);
    }

    public void SaveLevel(string Level){
        switch(Level){
            case "Level01":
                gameData.Level02 = true;
                break;
            case "Level02":
                gameData.Level03 = true;
                break;
            case "Level03":
                gameData.Level04 = true;
                break;

            default:
                Debug.Log("Error detecting level");
                break;
        }

        WriteFile();
        ReadFile();
        Debug.Log(FileContents);

    }
}

[System.Serializable]
public class GameData{
    public bool Level01 = true;
    public bool Level02;
    public bool Level03;
    public bool Level04;
}
