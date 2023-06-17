using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsTroops : MonoBehaviour
{
    [SerializeField] private TroopsManager troopsManager;


    public void produceTroopsLittle(){
        troopsManager.produceTroopLittle();
    }

    public void produceTroopsBig(){
        troopsManager.produceTroopBig();
    }


    
}
