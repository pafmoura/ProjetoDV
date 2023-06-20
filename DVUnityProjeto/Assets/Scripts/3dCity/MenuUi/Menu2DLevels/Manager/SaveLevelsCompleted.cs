using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLevelsCompleted : MonoBehaviour
{
    
    [SerializeField] private Games2dManager games2dManager;



    private static void SaveToJson<T>(T data, string filePath)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
    }

    private  T LoadFromJson<T>(string filePath)
    {
        string json = File.ReadAllText(filePath);
        T data = JsonUtility.FromJson<T>(json);
        return data;
    }


    public void saveLevelsCompleted(){
        SaveGame2d saveData = new SaveGame2d();
        saveData.levelComplete = games2dManager.getLevelComplete();
        SaveToJson(saveData, Application.dataPath + "/SaveData/LevelsCompleted.json");
    }


    private void inicialLevel(){
        games2dManager.setLevelComplete(1);


        
    }

    public void loadLevel2dFormJson(){
       /* if(File.Exists(Application.dataPath + "/SaveData/LevelsCompleted.json")){
            SaveGame2d saveData= LoadFromJson<SaveGame2d>(Application.dataPath + "/SaveData/LevelsCompleted.json");
            games2dManager.setLevelComplete(saveData.levelComplete);
        }else {
            inicialLevel();
        }*/
    }


    void OnApplicationQuit(){
        saveLevelsCompleted();
    }

}


[System.Serializable]
public class SaveGame2d{
    public int levelComplete;
}
