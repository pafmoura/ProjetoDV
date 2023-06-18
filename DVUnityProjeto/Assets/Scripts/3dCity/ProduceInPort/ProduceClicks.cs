using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "ProduceClicks", menuName = "Scriptable Objects/ProduceClicks")]
public class ProduceClicks : ScriptableObject
{
    [SerializeField] private int woodProduce=10;
    [SerializeField] private int rockProduce=10;
    [SerializeField] private int foodProduce=10;



    [SerializeField] private LevelBuilds port;




    //get 
    public int getWoodProduce(){
        return woodProduce*port.getNumberLevel();
    }

    public int getRockProduce(){
        return rockProduce*port.getNumberLevel();
    }

    public int getFoodProduce(){
        return foodProduce*port.getNumberLevel();
    }


}
