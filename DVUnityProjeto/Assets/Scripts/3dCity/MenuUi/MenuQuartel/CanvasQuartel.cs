using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasQuartel : MonoBehaviour
{
    [SerializeField] private GameObject buttonProduceTroops;



    public void isQuartel(LevelBuilds levelBuilds){

        if(levelBuilds.getBuildName() == "Quartel" ){
            buttonProduceTroops.SetActive(true);
            }else{
                buttonProduceTroops.SetActive(false);
            }
    }
    
}
