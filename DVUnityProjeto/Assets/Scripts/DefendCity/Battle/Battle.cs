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

    private bool isBattleFinished = false;


    [SerializeField] private SaveGameBattle SaveGameBattle;

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
        if(isBattleStarted && !isBattleFinished){
            if (countEnemys() == 0)
            {
                isBattleFinished = true;
                Debug.Log("You win!");
                townHall.upgradelevel();
                imageWinLose.sprite = imageWin;
                canvasWinLose.SetActive(true);
                Time.timeScale = 0;
                SaveGameBattle.saveAll();
            }

            if (countAllys() == 0)
            {
                isBattleFinished = true;
                Debug.Log("You lose!");
                imageWinLose.sprite = imageLose;
                SaveGameBattle.saveAll();
                canvasWinLose.SetActive(true);
                Time.timeScale = 0;

                
            }
        }
    }

}
