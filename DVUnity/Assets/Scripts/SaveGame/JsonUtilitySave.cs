using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class JsonUtilitySave : MonoBehaviour
{



    [SerializeField]private LevelBuilds farm;
    [SerializeField] private LevelBuilds mine;
    [SerializeField] private LevelBuilds sawmill;
    [SerializeField] private LevelBuilds market;
    [SerializeField] private LevelBuilds townhall;
    [SerializeField] private LevelBuilds port;

    [SerializeField] private ResourcesManager resourcesManager;
    

    //guardar os niveis que já se fez no 2d game

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

    public void Awake(){
        if(File.Exists(Application.dataPath + "/SaveData/LevelBuild.json")){
        farm.setLevelFromJson(LoadFromJson<Building>(Application.dataPath + "/SaveData/LevelBuild.json").levelFarm);
        }
    }



    public void saveBuilds(){
        Building building = new Building();
        building.levelFarm= farm.getNumberLevel(); 
        SaveToJson(building, Application.dataPath + "/SaveData/LevelBuild.json");
    }

   void OnApplicationQuit(){
        saveBuilds();
   }

}



//criar outra classe 
[System.Serializable]
public class Building{
    public int levelFarm;
    public int levelMine;
    public int levelSawmill;
    public int levelMarket;
    public int levelTownhall;
    public int levelPort;



}