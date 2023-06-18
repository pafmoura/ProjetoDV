using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShowMenuMarket : MonoBehaviour
{
    //trade 1
    [SerializeField] private Image resourceEarned1Image;
    [SerializeField] private Image resourceSpent1Image;

    [SerializeField] private TextMeshProUGUI amountEarned1Text;
    [SerializeField] private TextMeshProUGUI amountSpent1Text;


    //trade 2
    [SerializeField] private Image resourceEarned2Image;
    [SerializeField] private Image resourceSpent2Image;

    [SerializeField] private TextMeshProUGUI amountEarned2Text;
    [SerializeField] private TextMeshProUGUI amountSpent2Text;

    //buttons 
    [SerializeField] private Button trade1Button;
    [SerializeField] private Button trade2Button;

    [SerializeField] private TradeManager tradeManager;


    private Trade trade1;
    private Trade trade2;


    void Start(){
        updateUI();
        
    }

    public void updateUI(){
        tradeManager.generateAllTrades();

        //trade 1
         trade1 = tradeManager.Trade1;
        resourceEarned1Image.sprite = trade1.ResourceEarned.ResourceImage;
        resourceSpent1Image.sprite = trade1.ResourceSpent.ResourceImage;
        amountEarned1Text.text = trade1.AmountEarned.ToString();
        amountSpent1Text.text = trade1.AmountSpent.ToString();


        //trade2
         trade2 = tradeManager.Trade2;
        resourceEarned2Image.sprite = trade2.ResourceEarned.ResourceImage;
        resourceSpent2Image.sprite = trade2.ResourceSpent.ResourceImage;
        amountEarned2Text.text = trade2.AmountEarned.ToString();
        amountSpent2Text.text = trade2.AmountSpent.ToString();



        checkCanTrade();
    
    }



   
   //check if the player has enough resources to trade
   private void checkCanTrade(){
    //trade 1
    if( tradeManager.checkTrade(trade1)){
        trade1Button.interactable = true; 
        }else{
            trade1Button.interactable = false; 
        }


    if( tradeManager.checkTrade(trade2)){
        trade2Button.interactable = true; 
        }else{
            trade2Button.interactable = false; 
        }

   }






}
