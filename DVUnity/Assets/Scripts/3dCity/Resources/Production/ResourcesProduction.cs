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

    private double percentajeProductionOffline= 0.5; //50% of the production offline



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
        
        

        
       

        if(gameObject.name.Contains("Farm")){
            StartCoroutine(produceFood());
        }else if(gameObject.name.Contains("Rock")){
            StartCoroutine(produceRock());
        }else if(gameObject.name.Contains("Wood")){
            StartCoroutine(produceWood());  
        }
    }




    public void changeLevel(){
     
        level = levelBuilds.getNumberLevel();
        setIncrement();
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



    public int getIncrementWoodBySecondOffline(){
        changeLevel();
        return (int)(this.incrementWoodBySecond*percentajeProductionOffline);
    }
    public int getIncrementRockBySecondOffline(){
        changeLevel();
        return (int)(this.incrementRockBySecond*percentajeProductionOffline);
    }
    public int getIncrementFoodBySecondOffline(){
        changeLevel();
        return (int)(this.incrementFoodBySecond*percentajeProductionOffline);
    }


}


