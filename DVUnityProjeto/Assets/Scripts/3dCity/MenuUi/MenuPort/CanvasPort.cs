using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPort : MonoBehaviour
{

    [SerializeField] private GameObject menuPort;
    
    public void isPortBuild(LevelBuilds levelBuilds){
        
        if(levelBuilds.getBuildName() == "Dock" ){
            menuPort.SetActive(true);
            }else{
                menuPort.SetActive(false);
            }
    }
}
