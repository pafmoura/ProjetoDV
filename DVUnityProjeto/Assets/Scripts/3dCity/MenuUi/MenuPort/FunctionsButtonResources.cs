using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionsButtonResources : MonoBehaviour
{
    
    
    [SerializeField] private ResourcesManager resourcesManager;

    [SerializeField] private ProduceClicks produceClicks;


    [SerializeField] private GameObject menuToExit;
   
    public void produceWoodByClick(){
        resourcesManager.addWood(produceClicks.getWoodProduce());

    }

    public void produceRockByClick(){
        resourcesManager.addRock(produceClicks.getRockProduce());

    }

    public void produceFoodByClick(){
        resourcesManager.addFood(produceClicks.getFoodProduce());

    }
    

    public void exitMenu(){
        menuToExit.SetActive(false);
    }



}
