using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu (fileName = "TradeManager", menuName = "TradeManager")]
public class TradeManager : ScriptableObject
{

    
    
     private Trade trade1;
     private Trade trade2;

    [SerializeField] private Sprite wood;
    [SerializeField] private Sprite food;
    [SerializeField] private Sprite rock;


    //list with all the enum values
    private List<ResourceEnum> resourceEnums = new List<ResourceEnum>();

    private List<ResourceEnum> resourceEarnedEnums = new List<ResourceEnum>();

    [SerializeField] private LevelBuilds market;


    [SerializeField] private int amountToEarn=100;
    [SerializeField] private int amountToSpend=100;


    [SerializeField] private ResourcesManager resourcesManager;



    void OnEnable(){
        market.OnBuildLevelChanged += generateAllTrades;
    }

    void OnDisable(){
        market.OnBuildLevelChanged -= generateAllTrades;
    }





    void addEnumToList(){
        resourceEnums.Clear();
        resourceEnums.Add(ResourceEnum.Food);
        resourceEnums.Add(ResourceEnum.Wood);
        resourceEnums.Add(ResourceEnum.Rock);
        
    }


    void addEnumToListEarned(){
        resourceEarnedEnums.Clear();
        resourceEarnedEnums.Add(ResourceEnum.Food);
        resourceEarnedEnums.Add(ResourceEnum.Wood);
        resourceEarnedEnums.Add(ResourceEnum.Rock);
        
    }


    
    void generateTrade(Trade trade){

        
        
        trade.AmountEarned = market.getNumberLevel()* amountToEarn; 
        trade.AmountSpent = market.getNumberLevel()* amountToSpend;

        //choose a random resource for the trade

        
        trade.ResourceEarned.ResourceType = resourceEarnedEnums[Random.Range(0,resourceEarnedEnums.Count)];
        trade.ResourceEarned.ResourceImage = whatResourceIs(trade.ResourceEarned.ResourceType);

        //remove the resource from the list
        resourceEnums.Remove(trade.ResourceEarned.ResourceType);
        resourceEarnedEnums.Remove(trade.ResourceEarned.ResourceType);

        //choose a random resource for the trade
        trade.ResourceSpent.ResourceType = resourceEnums[Random.Range(0,resourceEnums.Count)];
        trade.ResourceSpent.ResourceImage = whatResourceIs(trade.ResourceSpent.ResourceType);

        

        
        


        //put the resource back in the list
        addEnumToList();
    }





    public void generateAllTrades(){
        addEnumToList();
        addEnumToListEarned();
        trade1 = new Trade();
        trade2 = new Trade();

        generateTrade(trade1);
        generateTrade(trade2);
    }





    private Sprite whatResourceIs(ResourceEnum resource){
        
        switch(resource){
            case ResourceEnum.Food:
                return food;
            case ResourceEnum.Wood:
                return wood;
            case ResourceEnum.Rock:
                return rock;
            default:
                return null;
        }
    }


    //get trades
    public Trade Trade1 { get => trade1;  }
    public Trade Trade2 { get => trade2;  }




    public bool checkTrade(Trade trade){
        if(trade.ResourceSpent.ResourceType == ResourceEnum.Food){
            if(resourcesManager.getFood() >= trade.AmountSpent){
                return true;
            }
        }
        else if(trade.ResourceSpent.ResourceType == ResourceEnum.Wood){
            if(resourcesManager.getWood() >= trade.AmountSpent){
                return true;
            }
        }
      else if(trade.ResourceSpent.ResourceType == ResourceEnum.Rock){
            if(resourcesManager.getRock() >= trade.AmountSpent){
                return true;
            }
        }
        return false;
    }



    public void doTrade(Trade trade){
        if(trade.ResourceSpent.ResourceType == ResourceEnum.Food){
            resourcesManager.removeFood(trade.AmountSpent);
        }
        else if(trade.ResourceSpent.ResourceType == ResourceEnum.Wood){
            resourcesManager.removeWood(trade.AmountSpent);
        }
        else if(trade.ResourceSpent.ResourceType == ResourceEnum.Rock){
            resourcesManager.removeRock(trade.AmountSpent);
        }

        if(trade.ResourceEarned.ResourceType == ResourceEnum.Food){
            resourcesManager.addFood(trade.AmountEarned);
        }
        else if(trade.ResourceEarned.ResourceType == ResourceEnum.Wood){
            resourcesManager.addWood(trade.AmountEarned);
        }
        else if(trade.ResourceEarned.ResourceType == ResourceEnum.Rock){
            resourcesManager.addRock(trade.AmountEarned);
        }
    }
    
   
   
}
