using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemysLife", menuName = "Scriptable Objects/EnemysLife")]
public class EnemysLife : ScriptableObject
{

    [SerializeField] private int life = 3;
    [SerializeField] private int damage = 1;

//get life and damge
    public int getLife()
    {
        return life;
    }
    public int getDamage()
    {
        return damage;
    }



}
