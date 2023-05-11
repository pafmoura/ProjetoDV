using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CanvasResourcesProduction : MonoBehaviour
{


     //attributes to show the resources production
    [SerializeField] private GameObject resourcesProduction;
    [SerializeField] private TextMeshProUGUI production;

    [SerializeField] private ResourcesProduction ResourcesProductionWoodScript;
    [SerializeField] private ResourcesProduction ResourcesProductionRockScript;
    [SerializeField] private ResourcesProduction ResourcesProductionFoodScript;

    [SerializeField] private Image imageResourcesProduction;


    
     public void isProductionBuilding(LevelBuilds levelBuilds){
        if(levelBuilds.getBuildName() == "Farm" ){
            resourcesProduction.SetActive(true);
            production.text = ResourcesProductionFoodScript.getProducionByHour().ToString();
            imageResourcesProduction.sprite = levelBuilds.getIconProduction();
            }else if(   levelBuilds.getBuildName() == "Mina"){
                resourcesProduction.SetActive(true);
                production.text = ResourcesProductionRockScript.getProducionByHour().ToString();
                imageResourcesProduction.sprite = levelBuilds.getIconProduction();

            }else if( levelBuilds.getBuildName() == "Serraria"){
                resourcesProduction.SetActive(true);
                production.text = ResourcesProductionWoodScript.getProducionByHour().ToString();
                imageResourcesProduction.sprite = levelBuilds.getIconProduction();

            }
    }
}
