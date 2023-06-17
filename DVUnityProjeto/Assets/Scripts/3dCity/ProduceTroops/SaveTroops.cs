using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;
using System;

public class SaveTroops : MonoBehaviour
{
    
    [SerializeField] private TroopsManager troopsManager;

    
    
    public static void SaveToJson<T>(T data, string filePath)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
    }

    public static T LoadFromJson<T>(string filePath)
    {
        string json = File.ReadAllText(filePath);
        T data = JsonUtility.FromJson<T>(json);
        return data;
    }



    private void saveTroops(){
        TroopsNumber troops = new TroopsNumber();
        troops.currentTroopBig= troopsManager.getCurrentTroopBig();
        troops.currentTroopLittle= troopsManager.getCurrentTroopLittle();
        SaveToJson(troops,Application.dataPath + "/SaveData/Troops.json");
    }

    public void loadTroops(){
        if(File.Exists(Application.dataPath + "/SaveData/Troops.json")){
            TroopsNumber troops= LoadFromJson<TroopsNumber>(Application.dataPath + "/SaveData/Troops.json");
            troopsManager.setCurrentTroopBig(troops.currentTroopBig);
            troopsManager.setCurrentTroopLittle(troops.currentTroopLittle);
        }else {
            inicialTroops();
        }
    }

    private void inicialTroops(){
       
       troopsManager.setInicialValues();
   
    }
    

    void OnApplicationQuit(){
        saveTroops();
    }


    




}


[System.Serializable]
public class TroopsNumber
{
    public int currentTroopBig;
    public int currentTroopLittle;
}