using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new FeaturesTroop", menuName = "Scriptable Objects/FeaturesTroop")]
public class FeaturesTroop : ScriptableObject
{
  
    [SerializeField]private int attackDamage = 10;
    [SerializeField]private float movementSpeed = 2f;
    [SerializeField] private int inicialLife = 100;
  


    public int getAttackDamage(){
        return attackDamage;
    }

    
    public float getMovementSpeed(){
        return movementSpeed;
    }

    public int getInicialLife(){
        return inicialLife;
    }
  

  
}
