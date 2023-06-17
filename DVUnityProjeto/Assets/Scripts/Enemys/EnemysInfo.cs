using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemysInfo", menuName = "Scriptable Objects/EnemysInfo")]
public class EnemysInfo : ScriptableObject
{

    [SerializeField] private int maxHealth = 3;
    [SerializeField] private int damage = 1;

    [SerializeField] private float attackInterval = 2f; // intervalo mínimo entre ataques

//get life and damge
    public int getMaxHealth()
    {
        return maxHealth;
    }
    public int getDamage()
    {
        return damage;
    }
    //get attack interval
    public float getAttackInterval()
    {
        return attackInterval;
    }



}
