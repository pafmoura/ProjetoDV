using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "New Troop Manager", menuName = "Scriptable Objects/TroopManager")]
public class TroopsManager : ScriptableObject
{

       
    [SerializeField] private int maxTroopBig=20;
    [SerializeField] private int maxTroopLittle=10;



    [SerializeField] private int currentTroopBig=0;
    [SerializeField] private int currentTroopLittle=0;



    [SerializeField] private int multiplierCost=3;
    [SerializeField] private int defaultCostWoodBig=200; 
    [SerializeField] private int defaultCostRockBig=200;
    [SerializeField] private int defaultCostFoodBig=200;

    [SerializeField] private int defaultCostWoodLittle=100;
    [SerializeField] private int defaultCostRockLittle=100;
    [SerializeField] private int defaultCostFoodLittle=100;


  
     private int costProductionWoodBig;
     private int costProductionRockBig;
     private int costProductionFoodBig;

     private int costProductionWoodLittle;
     private int costProductionRockLittle;
     private int costProductionFoodLittle;

    



    [SerializeField] private LevelBuilds townHall;


    [SerializeField] private ResourcesManager resourcesManager;



    //events when the number of troops changes
    public event UnityAction OnTroopChanged;
   



    public void updateAll() {

        int level = townHall.getNumberLevel();

        switch (level)
        {
            case 1:
                maxTroopBig = 10;
                maxTroopLittle = 20;
                setCotsProductionBig(
                    defaultCostWoodBig*multiplierCost*level,
                    defaultCostRockBig*multiplierCost*level,
                    defaultCostFoodBig*multiplierCost*level
                );
                setCotsProductionLittle(
                    defaultCostWoodLittle*multiplierCost*level,
                    defaultCostRockLittle*multiplierCost*level,
                    defaultCostFoodLittle*multiplierCost*level
                );
                break;
            case 2:
                maxTroopBig = 30;
                maxTroopLittle = 40;
                setCotsProductionBig(
                    defaultCostWoodBig * multiplierCost * level,
                    defaultCostRockBig * multiplierCost * level,
                    defaultCostFoodBig * multiplierCost * level
                );
                setCotsProductionLittle(
                    defaultCostWoodLittle * multiplierCost * level,
                    defaultCostRockLittle * multiplierCost * level,
                    defaultCostFoodLittle * multiplierCost * level
                );
                break;
            case 3:
                maxTroopBig = 50;
                maxTroopLittle = 60;
                setCotsProductionBig(
                    defaultCostWoodBig * multiplierCost * level,
                    defaultCostRockBig * multiplierCost * level,
                    defaultCostFoodBig * multiplierCost * level
                );
                setCotsProductionLittle(
                    defaultCostWoodLittle * multiplierCost * level,
                    defaultCostRockLittle * multiplierCost * level,
                    defaultCostFoodLittle * multiplierCost * level
                );

                break;
            default:
                break;
        }
    }


    public void produceTroopBig() {
        if (currentTroopBig < maxTroopBig)
        {
          
          if(!resourcesManager.removeResourcesSafely(costProductionWoodBig, costProductionRockBig, costProductionFoodBig)){
                return;
          }
            currentTroopBig++;
            
            OnTroopChanged?.Invoke();
        }
    }


    public void produceTroopLittle()
    {
        if (currentTroopLittle < maxTroopLittle)
        {
            if(!resourcesManager.removeResourcesSafely(costProductionWoodLittle, costProductionRockLittle, costProductionFoodLittle)){
                return;
            }

            currentTroopLittle++;
            OnTroopChanged?.Invoke();
        }
    }



    public void removeTroopBig() {
        if (currentTroopBig > 0)
        {
            currentTroopBig--;
            OnTroopChanged?.Invoke();
        }
    }

    public void removeTroopLittle()
    {
        if (currentTroopLittle > 0)
        {
            currentTroopLittle--;
            OnTroopChanged?.Invoke();
        }
    }






    private void setCotsProductionBig(int wood, int rock, int food ) {
        costProductionWoodBig = wood;
        costProductionRockBig = rock;
        costProductionFoodBig = food;
     }

    private void setCotsProductionLittle(int wood, int rock, int food){
        costProductionWoodLittle = wood;
        costProductionRockLittle = rock;
        costProductionFoodLittle = food;
    }


    //get costs of production
    public int getWoodCostBig() {
        return costProductionWoodBig;
    }
    
    public int getRockCostBig()
    {
        return costProductionRockBig;
    }

    public int getFoodCostBig()
    {
        return costProductionFoodBig;
    }

    public int getWoodCostLittle()
    {
        return costProductionWoodLittle;
    }

    public int getRockCostLittle()
    {
        return costProductionRockLittle;
    }

    public int getFoodCostLittle()
    {
        return costProductionFoodLittle;
    }

    public int getCurrentTroopBig() {
        return currentTroopBig;
    }

    public int getCurrentTroopLittle()
    {
        return currentTroopLittle;
    }

    public int getMaxTroopBig()
    {
        return maxTroopBig;
    }

    public int getMaxTroopLittle()
    {
        return maxTroopLittle;
    }


    public void setInicialValues() {
        currentTroopBig = 0;
        currentTroopLittle = 0;
        
    }

    public void setCurrentTroopBig(int currentTroopBig) {
        this.currentTroopBig = currentTroopBig;
    }

    public void setCurrentTroopLittle(int currentTroopLittle)
    {
        this.currentTroopLittle = currentTroopLittle;
    }



    
    

   
   
}
