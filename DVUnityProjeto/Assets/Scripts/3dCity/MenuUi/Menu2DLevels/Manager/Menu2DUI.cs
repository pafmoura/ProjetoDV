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


    public void Start(){
        updateUI();
    }

    public void updateUI(){
        
        int levelsComplete = games2dManager.getLevelComplete();


        for(int i=0; i<levelsComplete; i++){

            if(i==levelsComplete-1){
                levelsButtons[i].interactable = true;
                locks[i].SetActive(false);
                checks[i].SetActive(false);
                
                continue;
            }
            locks[i].SetActive(false);
            checks[i].SetActive(true);
            levelsButtons[i].interactable = false;
            
        }

        //for the levels that are complete, make the lock visible and the check invisible and not interactable
        for(int i=levelsComplete; i<locks.Length; i++){
            locks[i].SetActive(true);
            checks[i].SetActive(false);
            levelsButtons[i].interactable = false;
        }



    }
}
