using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Games2dManager", menuName = "Scriptable Objects/Games2dManager")] 
public class Games2dManager : ScriptableObject
{
    
    [SerializeField] private int levelComplete=1;




    public void completeLevel(){
        levelComplete++;
    }


    public int getLevelComplete(){
        return levelComplete;
    }

    public void setLevelComplete(int level){
        levelComplete = level;
    }





}
