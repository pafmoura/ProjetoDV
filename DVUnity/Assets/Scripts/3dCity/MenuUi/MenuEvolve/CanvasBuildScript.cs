using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CanvasBuildScript : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI buildingName;
    
   
    [SerializeField] private EvolveScript buildFarm;
    [SerializeField] private EvolveScript buildWood;
    [SerializeField] private EvolveScript buildRock;
    [SerializeField] private EvolveScript buildPort;
    [SerializeField] private EvolveScript buildTownHall;
    [SerializeField] private EvolveScript buildQuartel;
    [SerializeField] private EvolveScript buildMarket;

    [SerializeField] private FunctionsButtonsEvolve functionsButtonsEvolveScript;




    public void enableCanvas(string name)
    {    

        gameObject.SetActive(true);
        buildingName.text = name;
        functionsButtonsEvolveScript.setLevelBuilds(whatEvolveBuildIs(name));
    }



    public void disableCanvas()
    {
        gameObject.SetActive(false);
    }


    private EvolveScript whatEvolveBuildIs(string name){
        switch (name)
        {
            case "Farm":
                return buildFarm;
            case "Sawmill":
                return buildWood;
            case "Mine":
            Debug.Log("entrou no mine");
                    return buildRock;
            case "Port":
                    return buildPort;
            case "TownHall":
                    return buildTownHall;
            case "Quartel":
                    return buildQuartel;
            case "Market":
                    return buildMarket;
                    

            default: 
                return null;
        }
    }
}
