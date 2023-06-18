using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class SaveGameBattle : MonoBehaviour
{


    [SerializeField]private LevelBuilds farm;
    [SerializeField] private LevelBuilds mine;
    [SerializeField] private LevelBuilds sawmill;
    [SerializeField] private LevelBuilds market;
    [SerializeField] private LevelBuilds townhall;
    [SerializeField] private LevelBuilds port;
    [SerializeField] private LevelBuilds quartel;

    [SerializeField] private TroopsManager troopsManager;


    public static void SaveToJson<T>(T data, string filePath)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
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

    }

    private void saveTroops(){
        TroopsNumber troops = new TroopsNumber();
        troops.currentTroopBig= troopsManager.getCurrentTroopBig();
        troops.currentTroopLittle= troopsManager.getCurrentTroopLittle();
        SaveToJson(troops,Application.dataPath + "/SaveData/Troops.json");
    }

    public void saveAll(){
        saveBuilds();
        saveTroops();
    }

}











