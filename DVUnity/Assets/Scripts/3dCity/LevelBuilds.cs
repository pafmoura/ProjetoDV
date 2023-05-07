using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "LevelBuild", menuName = "Scriptable Objects/Village/LevelBuilds")]
public class LevelBuilds : ScriptableObject   

{       
    [SerializeField] private int level = 1; 

        [SerializeField] GameObject level1 ;
        
        [SerializeField] GameObject level2 ;
        
        [SerializeField] GameObject level3 ;


        [SerializeField] int foodLevel2=100;
        [SerializeField] int rockLevel2=100;
        [SerializeField] int woodLevel2=100;

        [SerializeField] int foodLevel3=100;
        [SerializeField] int rockLevel3=100;
        [SerializeField] int woodLevel3=100;
        
        [SerializeField] ResourcesManager resourcesManager;


        [SerializeField] string description;
        [SerializeField] string buildName;



        public event UnityAction OnBuildLevelChanged;
   


        //get all the levels
        public GameObject getLevel()
        {
            switch (level)
            {
                case 1:
                    return level1;
                case 2:
                    return level2;
                case 3:
                    return level3;
                default:
                    return null;
            }
        }

        public void resetLevel(){
            level = 1;
        }

        public void upgradelevel(){
            if(level < 3){
            level++;
            OnBuildLevelChanged?.Invoke();
            }
        }


        public bool UpgradeLevel(){

            if(level== 1){
            if (resourcesManager.getFood()>= foodLevel2 &&resourcesManager.getRock()>= rockLevel2 && resourcesManager.getWood()>= woodLevel2   ){
                resourcesManager.removeResources(foodLevel2,rockLevel2,woodLevel2);
                return true;
            }       else{
                return false;
                }
            }
            else if(level== 2){
                if (resourcesManager.getFood()>= foodLevel2 &&resourcesManager.getRock()>= rockLevel2 && resourcesManager.getWood()>= woodLevel2   ){
                resourcesManager.removeResources(foodLevel2,rockLevel2,woodLevel2);
                return true;
                }else{
                return false;
                }
            }else{
                return false;
            }
            
        }

        public bool canUpgrade(){   
            if(level== 1){
            return (resourcesManager.getFood()>= foodLevel2 &&resourcesManager.getRock()>= rockLevel2 && resourcesManager.getWood()>= woodLevel2   );
            }
            
            else if(level== 2){
                return (resourcesManager.getFood()>= foodLevel2 &&resourcesManager.getRock()>= rockLevel2 && resourcesManager.getWood()>= woodLevel2);          
            }else{
                return false;
                }
        }

       
        //getters

        public int getFoodLevelUpgrade(){
           switch(this.level){
                case 1:
                return foodLevel2;
                case 2:
                return foodLevel3;
                default:
                return 0;
           }
        }
        public int getRockLevelUpgrade(){
            switch(level){
                case 1:
                return rockLevel2;
                case 2:
                return rockLevel3;
                default:
                return 0;

            }
           
        }
        public int getWoodLevelUpgrade(){
            switch(level){
                case 1:
                return woodLevel2;
                case 2:
                return woodLevel3;
                default:
                return 0;
            }
           
        }

        public int getNumberLevel(){
            return level;
        }


    public string getDescription(){
    return description;
    }
    public string getBuildName(){

    return this.buildName;
    }




}
