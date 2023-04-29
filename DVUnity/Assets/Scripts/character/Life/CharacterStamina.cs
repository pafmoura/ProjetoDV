using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[   CreateAssetMenu(fileName = "Stamina", menuName = "Scriptable Objects/Stamina")]
public class CharacterStamina : ScriptableObject
{

    [SerializeField] private int maxStamina;
    [SerializeField] private int stamina;

    public HealthBar healthBar;

    public int getMaxStamina(){
        return maxStamina;
    }
    //get the current stamina
    public int getStamina(){
        return stamina;
    }

    public void setStamina(int damage){
        stamina -= damage;
    }

    public void resetStamina(){
        stamina = maxStamina;
    }

    public void TakeDamage(int damage) {
        stamina -= damage;
    }
}
