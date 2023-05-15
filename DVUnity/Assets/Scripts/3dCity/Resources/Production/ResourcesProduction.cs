using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class ResourcesProduction : MonoBehaviour
{


    [SerializeField] private LevelBuilds currentLevelBuilds;
    [SerializeField] private ResourcesManager resourcesManager;
    private int level;

    //private int incrementWoodBySecond;
   // private int incrementRockBySecond;
    //private int incrementFoodBySecond;
    private int incrementBySecond;
    
    private DateTime lastProductionTime;

    private double percentajeProductionOffline= 0.5; //50% of the production offline


    [SerializeField] private int multiplierProduction= 10;



    


       private void OnEnable()
    {
        currentLevelBuilds.OnBuildLevelChanged += changeLevel;
    }
    private void OnDisable()
    {
    currentLevelBuilds.OnBuildLevelChanged -= changeLevel;
    }


    private void setIncrement(){
       // incrementWoodBySecond= level*multiplierProduction;
     //   incrementRockBySecond= level*10;
    //    incrementFoodBySecond= level*10;
        incrementBySecond= level*multiplierProduction;
    }
   



   
    void Start()
    {

       
       

        changeLevel();
        

        if(gameObject.name.Contains("Farm")){
            StartCoroutine(produceFood());
        }else if(gameObject.name.Contains("Rock")){
            StartCoroutine(produceRock());
        }else if(gameObject.name.Contains("Wood")){
            StartCoroutine(produceWood());  
        }
    }






    public void changeLevel(){
      
        level = currentLevelBuilds.getNumberLevel();
        setIncrement();
    }



    
    IEnumerator produceFood(){
     
            yield return new WaitForSeconds(1f);
            resourcesManager.addFood(incrementBySecond);
            StartCoroutine(produceFood());
        
    }

    IEnumerator produceRock(){
        
            yield return new WaitForSeconds(1f);
            resourcesManager.addRock(incrementBySecond);
            StartCoroutine(produceRock());
        
    }

    IEnumerator produceWood(){
        
            yield return new WaitForSeconds(1f);
            resourcesManager.addWood(incrementBySecond);
            StartCoroutine(produceWood());
        
    }

/*
    public int getProducionByHourWood(){
        return incrementWoodBySecond*3600;  
    }
    public int getProducionByHourRock(){
        return incrementRockBySecond*3600;  
    }
    public int getProducionByHourFood(){
        return incrementFoodBySecond*3600;  
    }



    public int getIncrementWoodBySecondOffline(){
        
        return (int)(this.incrementWoodBySecond*percentajeProductionOffline);
    }
    public int getIncrementRockBySecondOffline(){
        
        return (int)(this.incrementRockBySecond*percentajeProductionOffline);
    }
    public int getIncrementFoodBySecondOffline(){
        
        
        return (int)(this.incrementFoodBySecond*percentajeProductionOffline);
    }
*/
    public int getProducionByHour(){
        return incrementBySecond*3600;  
    }
    
    public int getIncrementBySecondOffline(){
        
        return (int)(this.incrementBySecond*percentajeProductionOffline);
    }

}


