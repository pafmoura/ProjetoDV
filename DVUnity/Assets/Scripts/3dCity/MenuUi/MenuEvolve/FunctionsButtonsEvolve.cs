using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FunctionsButtonsEvolve : MonoBehaviour
{
    
    //script to manage the buttons of the evolve build

    [SerializeField] private ResourcesManager resourcesManager;
    [SerializeField] private TextMeshProUGUI buildingName;

    [SerializeField] private EvolveScript evolveScript ; //scrit to manage the evolve of the build
    [SerializeField] private LevelBuilds levelBuilds; //scriptable object to manage the levels of the build


    [SerializeField] private CanvasBuildScript canvasBuildScript; //script to manage the canvas of the build

    public void evolveBuild()
    {   
        //function to evolve the build
        //this will be changed for calling a funtion of the levelbuilds scriptable object that says how much resources are needed to upgrade the build 
        resourcesManager.removeWood(50);

        evolveScript.evolveBuild();

        canvasBuildScript.disableCanvas();


        
        
    }


    public void setLevelBuilds(EvolveScript evolveScript){
        this.evolveScript = evolveScript;
        this.levelBuilds = evolveScript.getLevelBuilds();
    }

    




}
