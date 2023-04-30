using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEndGame : MonoBehaviour
{
    
    //strat
    void Start()
    {

    }

    public void exitGame(){
        Debug.Log("Continue Game");
        SceneManager.LoadSceneAsync("Village Level1");
    }

    public void restartGame(){
        SceneManager.LoadSceneAsync("Nivel1");
    }

    
}
