using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleLevel : MonoBehaviour
{
    
    [SerializeField] private LevelBuilds townHall;

    [SerializeField] private GameObject level1 ;
    [SerializeField] private GameObject level2 ;
    


    void Start(){
        showBattleLevel();
    }


    private void showBattleLevel(){
        switch(townHall.getNumberLevel()){
            case 1:
                level1.SetActive(true);
                level2.SetActive(false);
                break;
            case 2:
                level2.SetActive(true);
                level1.SetActive(false);
                break;
        }
    }

}
