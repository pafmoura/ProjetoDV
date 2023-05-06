using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CanvasBuildScript : MonoBehaviour
{



    
   
    [SerializeField] private EvolveScript buildFarm;
    [SerializeField] private EvolveScript buildWood;
    [SerializeField] private EvolveScript buildRock;
    [SerializeField] private EvolveScript buildPort;
    [SerializeField] private EvolveScript buildTownHall;
    [SerializeField] private EvolveScript buildQuartel;
    [SerializeField] private EvolveScript buildMarket;

    [SerializeField] private FunctionsButtonsEvolve functionsButtonsEvolveScript;


    [SerializeField] private TextMeshProUGUI buildName;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI level;
    [SerializeField] private TextMeshProUGUI food;
    [SerializeField] private TextMeshProUGUI wood;
    [SerializeField] private TextMeshProUGUI rock;

    [SerializeField] private TextMeshProUGUI notEnoughResources;


    [SerializeField] private Button buttonEvolveBuild;



    public void enableCanvas(string name)
    {    

        LevelBuilds levelBuilds = whatEvolveBuildIs(name).getLevelBuilds();
        areResourcesUnsuficient(levelBuilds);

        this.description.text = levelBuilds.getDescription().ToString();
        this.level.text = levelBuilds.getNumberLevel().ToString();
        this.food.text = levelBuilds.getFoodLevelUpgrade().ToString();
        this.wood.text = levelBuilds.getWoodLevelUpgrade().ToString();
        this.rock.text = levelBuilds.getRockLevelUpgrade().ToString();
        this.buildName.text = levelBuilds.getBuildName().ToString();
        functionsButtonsEvolveScript.setLevelBuilds(whatEvolveBuildIs(name));
        
        

        gameObject.SetActive(true);
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



    public void areResourcesUnsuficient(LevelBuilds levelBuilds){
    
        if(!levelBuilds.canUpgrade()){
        notEnoughResources.gameObject.SetActive(true);
        buttonEvolveBuild.interactable = false;
        buttonEvolveBuild.GetComponent<Image>().color = Color.gray;
         }else{
            notEnoughResources.gameObject.SetActive(false);
            buttonEvolveBuild.interactable = true;
            buttonEvolveBuild.GetComponent<Image>().color = Color.white;
         }
    }
}
