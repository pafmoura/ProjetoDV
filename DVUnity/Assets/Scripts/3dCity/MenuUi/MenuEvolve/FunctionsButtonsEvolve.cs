using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FunctionsButtonsEvolve : MonoBehaviour
{
    
    //script to manage the buttons of the evolve build

    [SerializeField] private ResourcesManager resourcesManager;
    

    private EvolveScript evolveScript ; //scrit to manage the evolve of the build
    private LevelBuilds levelBuilds; //scriptable object to manage the levels of the build


    [SerializeField] private CanvasBuildScript canvasBuildScript; //script to manage the canvas of the build

    public void buttonEvolveBuild()
    {   
        //function to evolve the build
        //this will be changed for calling a funtion of the levelbuilds scriptable object that says how much resources are needed to upgrade the build 
        if(levelBuilds.UpgradeLevel()){
            
            
        evolveScript.evolveBuild();

        canvasBuildScript.disableCanvas();
    
        }
        else{

            //show a message that the resources are unsuficient
            
        }
        
        

        
        
    }


    public void setLevelBuilds(EvolveScript evolveScript){
        this.evolveScript = evolveScript;
        this.levelBuilds = evolveScript.getLevelBuilds();
    }

    




}
