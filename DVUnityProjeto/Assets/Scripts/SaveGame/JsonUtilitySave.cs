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
    
    [SerializeField] private SaveProductionOffline saveProductionOffline;

    [SerializeField] private SaveTroops saveTroops;
    
    [SerializeField] private SaveLevelsCompleted saveLevelsCompleted;

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
        setLevelsBuilds(buildsData);
        }else{
            //create file
            inicialBuilds();
        }

        //resources
        if(File.Exists(Application.dataPath + "/SaveData/Resources.json")){
            SaveResources resources= LoadFromJson<SaveResources>(Application.dataPath + "/SaveData/Resources.json");
            resourcesManager.setResources(resources.wood,resources.rock,resources.food);
        }else {
            inicialResources();
        }

        //production offline that shows how much resources you made offline
        saveProductionOffline.doProductionOffline();


       saveTroops.loadTroops();

       saveLevelsCompleted.loadLevel2dFormJson();
    }

    private void inicialBuilds(){
        Building building = new Building();
        setLevelsBuilds(building);
    }

    private void inicialResources(){
        SaveResources resources = new SaveResources();
        resourcesManager.setResources(resources.wood,resources.rock,resources.food);
    }



    private void setLevelsBuilds(Building building){
        farm.setLevelFromJson(building.levelFarm);
        mine.setLevelFromJson(building.levelMine);
        sawmill.setLevelFromJson(building.levelSawmill);
        market.setLevelFromJson(building.levelMarket);
        townhall.setLevelFromJson(building.levelTownhall);
        port.setLevelFromJson(building.levelPort);
        quartel.setLevelFromJson(building.levelQuartel);
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
        SaveToJson(resources, Application.dataPath + "/SaveData/Resources.json");
        
    }


   void OnApplicationQuit(){
        saveAll();
   }

    public void saveAll(){
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

[System.Serializable]
public class SaveResources{
    public int wood=0;
    public int rock=0;
    public int food=0;
}