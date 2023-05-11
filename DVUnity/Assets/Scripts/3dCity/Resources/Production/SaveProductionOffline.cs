using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class SaveProductionOffline : MonoBehaviour
{
 
    [SerializeField] private ResourcesManager resourcesManager;

    private DateTime lastProductionTime;

    [SerializeField] private ResourcesProduction resourcesProductionWood;
    [SerializeField] private ResourcesProduction resourcesProductionRock;
    [SerializeField] private ResourcesProduction resourcesProductionFood;
   
    [SerializeField] private GameObject canvasResourcesProductionOffline;

    [SerializeField] private ShowProductionOffline showProductionOfflineScript;

  

    public void doProductionOffline(){
        setUpLevels();

        if(File.Exists(Application.dataPath + "/SaveData/TimeLastProduction.json")){
            SaveTimeLastProduction saveTimeLastProduction= LoadFromJson<SaveTimeLastProduction>(Application.dataPath + "/SaveData/TimeLastProduction.json");
            lastProductionTime= DateTime.Parse(saveTimeLastProduction.lastProductionTime); // Converting string back to DateTime
            addProduction();
            
        }
    }


       public void setUpLevels(){
        resourcesProductionWood.changeLevel();
        resourcesProductionRock.changeLevel();
        resourcesProductionFood.changeLevel();   
    }



    private void addProduction(){
        TimeSpan timeSpan = DateTime.Now - lastProductionTime;
        int seconds = (int)timeSpan.TotalSeconds;
        

        int woodMade= seconds*resourcesProductionWood.getIncrementBySecondOffline();
        int rockMade= seconds*resourcesProductionRock.getIncrementBySecondOffline();
        int foodMade= seconds*resourcesProductionFood.getIncrementBySecondOffline();


        resourcesManager.addFood(foodMade);
        resourcesManager.addRock(rockMade);
        resourcesManager.addWood(woodMade);


        showProductionOfflineScript.showProductionOffline(woodMade,  rockMade,  foodMade);


        }


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

   
   
   
     void OnApplicationQuit(){
        saveTime();
        
   }



    private void saveTime(){
        SaveTimeLastProduction saveTimeLastProduction = new SaveTimeLastProduction();
        saveTimeLastProduction.lastProductionTime= DateTime.Now.ToString();
        
        SaveToJson(saveTimeLastProduction,Application.dataPath + "/SaveData/TimeLastProduction.json");
        
    }




}

[System.Serializable]
public class SaveTimeLastProduction
{
    public string lastProductionTime;
    
}

