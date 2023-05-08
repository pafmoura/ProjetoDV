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
    [SerializeField] private LevelBuilds quartel;

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

        //builds
        if(File.Exists(Application.dataPath + "/SaveData/LevelBuild.json")){
        Building buildsData= LoadFromJson<Building>(Application.dataPath + "/SaveData/LevelBuild.json");   
        farm.setLevelFromJson(buildsData.levelFarm);
        mine.setLevelFromJson(buildsData.levelMine);
        sawmill.setLevelFromJson(buildsData.levelSawmill);
        market.setLevelFromJson(buildsData.levelMarket);
        townhall.setLevelFromJson(buildsData.levelTownhall);
        port.setLevelFromJson(buildsData.levelPort);
        quartel.setLevelFromJson(buildsData.levelQuartel);
        }

        //resources
        if(File.Exists(Application.dataPath + "/SaveData/Resources.json")){
            SaveResources resources= LoadFromJson<SaveResources>(Application.dataPath + "/SaveData/Resources.json");
            resourcesManager.setResources(resources.wood,resources.rock,resources.food);
        }
    }



    private void saveBuilds(){
        Building building = new Building();
        building.levelFarm= farm.getNumberLevel(); 
        building.levelMine= mine.getNumberLevel();
        building.levelSawmill= sawmill.getNumberLevel();
        building.levelMarket= market.getNumberLevel();
        building.levelTownhall= townhall.getNumberLevel();
        building.levelPort= port.getNumberLevel();
        building.levelQuartel= quartel.getNumberLevel();
        SaveToJson(building, Application.dataPath + "/SaveData/LevelBuild.json");


        //save resources

    }

    private void saveResources(){
        SaveResources resources = new SaveResources();
        resources.wood= resourcesManager.getWood();
        resources.rock= resourcesManager.getRock();
        resources.food= resourcesManager.getFood();
        
    }


   void OnApplicationQuit(){
        saveBuilds();
        saveResources();
   }

}



//criar outra classe 
[System.Serializable]
public class Building{
    public int levelFarm=1;
    public int levelMine=1;
    public int levelSawmill=1;
    public int levelMarket=1;
    public int levelTownhall=1;
    public int levelPort=1;
    public int levelQuartel=1;

}


public class SaveResources{
    public int wood=100;
    public int rock=100;
    public int food=100;
}