using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class Battle : MonoBehaviour
{
    
    //button to start battle
    [SerializeField] private Button buttonStart;

    [SerializeField] private SpawnWarrior spawnWarriorScript;

    [SerializeField] private LevelBuilds townHall;
    [SerializeField] private GameObject canvasWinLose;

    [SerializeField] private Image imageWinLose;

    // image to show if win or  lose
    [SerializeField] private Sprite imageLose;
    [SerializeField] private Sprite imageWin;


    private bool isBattleStarted = false;

    void Awake(){
        
        buttonStart.interactable = true;
        spawnWarriorScript.enabled = true;
        Time.timeScale = 0;
    }


    public void buttonStartBattle(){
        buttonStart.interactable = false;
        spawnWarriorScript.enabled = false;
        Time.timeScale = 1;
        isBattleStarted = true;
    }




    private int countAllys()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("AllyWarrior");
        return objects.Length;
    }

    private int countEnemys()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");
        return objects.Length;
    }


    //if all enemys are dead, the player wins
    void Update()
    {
        if(isBattleStarted){
            if (countEnemys() == 0)
            {
                Debug.Log("You win!");
                townHall.upgradelevel();
                imageWinLose.sprite = imageWin;
                canvasWinLose.SetActive(true);
                Time.timeScale = 0;
            }

            if (countAllys() == 0)
            {
                Debug.Log("You lose!");
                imageWinLose.sprite = imageLose;
                canvasWinLose.SetActive(true);
                
                Time.timeScale = 0;
            }
        }
    }

}
