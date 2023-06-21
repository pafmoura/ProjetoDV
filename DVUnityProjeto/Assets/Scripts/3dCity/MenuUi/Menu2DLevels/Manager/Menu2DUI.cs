using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu2DUI : MonoBehaviour
{
    
    [SerializeField] private Games2dManager games2dManager;


    [SerializeField] private GameObject[] locks;
    [SerializeField] private GameObject[] checks;

    [SerializeField] private Button[] levelsButtons;

    [SerializeField] private LevelBuilds townHall;


    public void Start(){
        updateUI();
    }

    public void updateUI(){
        
        int levelsComplete = games2dManager.getLevelComplete();

        int levelOfTownHall = townHall.getNumberLevel();

        //if the player has completed all the levels, make the lock visible and the check invisible and not interactable
        if(levelsComplete == locks.Length+1){
            for(int i=0; i<locks.Length; i++){
                locks[i].SetActive(false);
                checks[i].SetActive(true);
                levelsButtons[i].interactable = false;
            }
            return;
        }



        for(int i=0; i<levelsComplete; i++){

            if(i==levelsComplete-1){

            
                if(levelOfTownHall == 1 && i==2){
                    locks[i].SetActive(true);
                    checks[i].SetActive(false);
                    levelsButtons[i].interactable = false;
                    //leave the cicle
                    break;
                }
                else if(levelOfTownHall== 2 && i==4){
                    locks[i].SetActive(true);
                    checks[i].SetActive(false);
                    levelsButtons[i].interactable = false;

                    //leave the cicle
                    break;

                }

                levelsButtons[i].interactable = true;
                locks[i].SetActive(false);
                checks[i].SetActive(false);
                
                continue;
            }

          

            locks[i].SetActive(false);
            checks[i].SetActive(true);
            levelsButtons[i].interactable = false;
            
        }

        //for the levels that are not complete, make the lock visible and the check invisible and not interactable
        for(int i=levelsComplete; i<locks.Length; i++){
            locks[i].SetActive(true);
            checks[i].SetActive(false);
            levelsButtons[i].interactable = false;
        }






    }
}
