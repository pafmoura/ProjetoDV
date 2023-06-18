using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsMarket : MonoBehaviour
{
    
    [SerializeField] private TradeManager tradeManager;

    [SerializeField] private GameObject menu;

    private Trade trade1;
    private Trade trade2;

    public void trade1Button(){
        trade1 = tradeManager.Trade1;
        tradeManager.doTrade(trade1);
    }

    public void trade2Button(){
        trade2 = tradeManager.Trade2;
        tradeManager.doTrade(trade2);
    }


    public void exitMenu(){
        menu.SetActive(false);

    }
}
