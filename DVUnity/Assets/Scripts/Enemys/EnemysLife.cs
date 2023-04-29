using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemysLife", menuName = "Scriptable Objects/EnemysLife")]
public class EnemysLife : ScriptableObject
{

    [SerializeField] private int maxHealth = 3;
    [SerializeField] private int damage = 1;

//get life and damge
    public int getMaxHealth()
    {
        return maxHealth;
    }
    public int getDamage()
    {
        return damage;
    }



}
