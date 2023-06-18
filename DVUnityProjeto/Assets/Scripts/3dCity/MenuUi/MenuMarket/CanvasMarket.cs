using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMarket : MonoBehaviour
{
     [SerializeField] private GameObject buttonMarket;
    
    public void isMarketBuild(LevelBuilds levelBuilds){
        
        if(levelBuilds.getBuildName() == "Mercado" ){
            buttonMarket.SetActive(true);
            }else{
                buttonMarket.SetActive(false);
            }
    }
}
