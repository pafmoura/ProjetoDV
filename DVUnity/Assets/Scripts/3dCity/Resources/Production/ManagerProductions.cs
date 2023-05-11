using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerProductions : MonoBehaviour
{
    [SerializeField] private ResourcesProduction resourcesProductionWood;
    [SerializeField] private ResourcesProduction resourcesProductionRock;
    [SerializeField] private ResourcesProduction resourcesProductionFood;


    public void setUpLevels(){
        resourcesProductionWood.changeLevel();
        resourcesProductionRock.changeLevel();
        resourcesProductionFood.changeLevel();   
    }

}
