using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
[CreateAssetMenu(fileName = "ResourcesManager", menuName = "Scriptable Objects/ResourcesManager")]
public class ResourcesManager : ScriptableObject
{

    [SerializeField] private int wood = 100;
    [SerializeField] private int rock=100;
    [SerializeField] private int food=100;

     //public ResourcesMenu resourcesMenu;

    //listener
    /*
    public delegate void ResourceCountChangedDelegate(int amount);
        public event ResourceCountChangedDelegate OnResourceWoodChanged;
        public event ResourceCountChangedDelegate OnResourceRockChanged;
        public event ResourceCountChangedDelegate OnResourceFoodChanged;
*/

        
    public  event UnityAction OnWoodCountChanged;
    public  event UnityAction OnRockCountChanged;
    public  event UnityAction OnFoodCountChanged;


     

    public void addWood(int amount){
       if(wood >= amount){
        wood += amount;
        OnWoodCountChanged?.Invoke();
        }
    }
    public void removeWood(int amount){
    if(wood >= amount){
        wood -= amount;
        OnWoodCountChanged?.Invoke();
        }
    }


    public void addRock(int amount){
        if(rock >= amount){
        rock += amount;
        OnRockCountChanged?.Invoke();
        }
    }
    public void removeRock(int amount){
        if(rock >= amount){
        rock -= amount;
        OnRockCountChanged?.Invoke();
        }
    }


    public void addFood(int amount){
        if(food >= amount){
        food += amount;
        OnFoodCountChanged?.Invoke( );
        }
    }
    public void removeFood(int amount){
        if(food >= amount){
        food -= amount;
        OnFoodCountChanged?.Invoke();
        }
    }


  //getters
  public int getWood(){
      return wood;
  }
    public int getRock(){
        return rock;
    }
    public int getFood(){
        return food;
    }


}



