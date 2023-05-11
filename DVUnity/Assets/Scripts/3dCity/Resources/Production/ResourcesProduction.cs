using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class ResourcesProduction : MonoBehaviour
{


    [SerializeField] private LevelBuilds levelBuilds;
    [SerializeField] private ResourcesManager resourcesManager;
    private int level;

    private int incrementWoodBySecond;
    private int incrementRockBySecond;
    private int incrementFoodBySecond;
    
    private DateTime lastProductionTime;


       private void OnEnable()
    {
    levelBuilds.OnBuildLevelChanged += changeLevel;
    }
    private void OnDisable()
    {
    levelBuilds.OnBuildLevelChanged -= changeLevel;
    }


    private void setIncrement(){
        incrementWoodBySecond= level*10;
        incrementRockBySecond= level*10;
        incrementFoodBySecond= level*10;
    }
   
   
    void Start()
    {


        changeLevel();
        setIncrement();


        
        if(File.Exists(Application.dataPath + "/SaveData/TimeLastProduction.json")){
            SaveTimeLastProduction saveTImeLastProduction= LoadFromJson<SaveTimeLastProduction>(Application.dataPath + "/SaveData/TimeLastProduction.json");
            lastProductionTime= saveTImeLastProduction.lastProductionTime;
            addProduction();

        }

        if(gameObject.name.Contains("Farm")){
            StartCoroutine(produceFood());
        }else if(gameObject.name.Contains("Rock")){
            StartCoroutine(produceRock());
        }else if(gameObject.name.Contains("Wood")){
            StartCoroutine(produceWood());  
        }
    }




    private void changeLevel(){
        level = levelBuilds.getNumberLevel();
    }



    
    IEnumerator produceFood(){
     
            yield return new WaitForSeconds(1f);
            
            resourcesManager.addFood(incrementFoodBySecond);
            StartCoroutine(produceFood());
        
    }

    IEnumerator produceRock(){
        
            yield return new WaitForSeconds(1f);
            resourcesManager.addRock(incrementRockBySecond);
            StartCoroutine(produceRock());
        
    }

    IEnumerator produceWood(){
        
            yield return new WaitForSeconds(1f);
            resourcesManager.addWood(incrementWoodBySecond);
            StartCoroutine(produceWood());
        
    }


    public int getProducionByHourWood(){
        return incrementWoodBySecond*3600;  
    }
    public int getProducionByHourRock(){
        return incrementRockBySecond*3600;  
    }
    public int getProducionByHourFood(){
        return incrementFoodBySecond*3600;  
    }






    //methods to save the time of the last production



    private void addProduction(){
        TimeSpan timeSpan = DateTime.Now - lastProductionTime;
        int seconds = (int)timeSpan.TotalSeconds;
        resourcesManager.addFood(seconds*incrementFoodBySecond);
        resourcesManager.addRock(seconds*incrementRockBySecond);
        resourcesManager.addWood(seconds*incrementWoodBySecond);
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
        SaveTimeLastProduction saveTImeLastProduction = new SaveTimeLastProduction();
        saveTImeLastProduction.lastProductionTime= DateTime.Now;
        SaveToJson(saveTImeLastProduction,Application.dataPath + "/SaveData/TimeLastProduction.json");
    }


}
[Serializable]
public class SaveTimeLastProduction
{
    public DateTime lastProductionTime;
}
