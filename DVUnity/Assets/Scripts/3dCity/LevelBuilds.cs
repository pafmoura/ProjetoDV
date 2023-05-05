using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelBuild", menuName = "Scriptable Objects/Village/LevelBuilds")]
public class LevelBuilds : ScriptableObject   

{       
    [SerializeField] private int level = 1; 

        [SerializeField] GameObject level1 ;
        
        [SerializeField] GameObject level2 ;
        
        [SerializeField] GameObject level3 ;

//get all the levels
        public GameObject GetLevel()
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

        public void Upgradelevel(){
            if(level < 3){
            level++;
            }
        }



}
