using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


  //class to load the level of the game by the name 

public class LoadGamesButtons : MonoBehaviour
{


    [SerializeField] private JsonUtilitySave buildsAndResources;
    [SerializeField] private SaveProductionOffline productionOffline;



    public void loadLevel2d(int numberLevel){

        buildsAndResources.saveAll();
        productionOffline.saveAll();

            //Load the scene of the game
        SceneManager.LoadScene("Nivel"+numberLevel);

    }





}
