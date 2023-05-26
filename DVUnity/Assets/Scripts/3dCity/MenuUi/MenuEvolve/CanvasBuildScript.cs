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

    [SerializeField] private Image imageBuild;

    [SerializeField] private TextMeshProUGUI notEnoughResources;


    [SerializeField] private Button buttonEvolveBuild;


    [SerializeField] private GameObject evolutionCostsScriptUI;


    [SerializeField] private CanvasResourcesProduction canvasResourcesProductionScript;

   

    public void enableCanvas(string name)
    {    

        LevelBuilds levelBuilds = whatEvolveBuildIs(name).getLevelBuilds();

        if(checkCanEvolve(levelBuilds)){
        areResourcesUnsuficient(levelBuilds);
        }
       canvasResourcesProductionScript.isProductionBuilding(levelBuilds);

        this.description.text = levelBuilds.getDescription().ToString();
        this.level.text = levelBuilds.getNumberLevel().ToString();
        this.food.text = levelBuilds.getFoodLevelUpgrade().ToString();
        this.wood.text = levelBuilds.getWoodLevelUpgrade().ToString();
        this.rock.text = levelBuilds.getRockLevelUpgrade().ToString();
        this.buildName.text = levelBuilds.getBuildName().ToString();
        this.imageBuild.sprite = levelBuilds.getImageBuild();
        functionsButtonsEvolveScript.setLevelBuilds(whatEvolveBuildIs(name));
        
        

        gameObject.SetActive(true);
    }




   





    public void disableCanvas()
    {
        gameObject.SetActive(false);
    }


    public EvolveScript whatEvolveBuildIs(string name){
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
        //level max
        if(levelBuilds.getNumberLevel()== 3){
            Debug.Log("Max Level");
            notEnoughResources.text= "Max Level";
            evolutionCostsScriptUI.SetActive(false);
            notEnoughResources.gameObject.SetActive(true);
            buttonEvolveBuild.interactable = false;
            buttonEvolveBuild.GetComponent<Image>().color = Color.gray;
            }      
        else if(!levelBuilds.canUpgrade()){ // se nao tiver recursos suficientes
            notEnoughResources.text = "Recursos Insuficientes";
            notEnoughResources.gameObject.SetActive(true);
            buttonEvolveBuild.interactable = false;
            buttonEvolveBuild.GetComponent<Image>().color = Color.gray;
        }else{ // se tiver recursos suficientes
            notEnoughResources.gameObject.SetActive(false);
            evolutionCostsScriptUI.SetActive(true);
            buttonEvolveBuild.interactable = true;
            buttonEvolveBuild.GetComponent<Image>().color = Color.white;
         }
    }

    private bool checkCanEvolve(LevelBuilds levelBuilds){
        
        if(levelBuilds.isTownHallBuild()){
            if(!townHallCanUpgrade(levelBuilds)){
                notEnoughResources.text= "First Evolve the others buildings";
                notEnoughResources.gameObject.SetActive(true);
                buttonEvolveBuild.interactable = false;
                buttonEvolveBuild.GetComponent<Image>().color = Color.gray;
                return false;
            }
            Debug.Log("TownHall");
        }else if(levelBuilds.getNumberLevel() > buildTownHall.getLevelBuilds().getNumberLevel()){ // se o nivel do edificio for maior que o do townhall
            notEnoughResources.text= "First Evolve the TownHall";
            notEnoughResources.gameObject.SetActive(true);
            buttonEvolveBuild.interactable = false;
            buttonEvolveBuild.GetComponent<Image>().color = Color.gray;
            return false;
        }
        return true;
    }

    private bool townHallCanUpgrade(LevelBuilds townhall){

        if(townhall.getNumberLevel() == 3){
            return true;
        }


        if(buildFarm.getLevelBuilds().getNumberLevel() <= townhall.getNumberLevel()){
            return false;
        }else if(   buildWood.getLevelBuilds().getNumberLevel() <= townhall.getNumberLevel()){
            return false;
        }else if(   buildRock.getLevelBuilds().getNumberLevel() <= townhall.getNumberLevel()){
            return false;
        }else if(   buildPort.getLevelBuilds().getNumberLevel() <= townhall.getNumberLevel()){
            return false;
        }else if(   buildQuartel.getLevelBuilds().getNumberLevel() <= townhall.getNumberLevel()){
            return false;
        }else if(   buildMarket.getLevelBuilds().getNumberLevel() <= townhall.getNumberLevel()){
            return false;
        }else{
            return true;
        }


    

    }



}
