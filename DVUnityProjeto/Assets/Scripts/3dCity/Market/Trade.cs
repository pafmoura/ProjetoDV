using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Trade 
{

    [SerializeField] private int amountEarned;
    [SerializeField] private int amountSpent;   

    
    [SerializeField] private ResourceInfo resourceEarned = new ResourceInfo();
    [SerializeField] private ResourceInfo resourceSpent = new ResourceInfo();



    public int AmountEarned { get => amountEarned; set => amountEarned = value; }
    public int AmountSpent { get => amountSpent; set => amountSpent = value; }



    public ResourceInfo ResourceEarned { get => resourceEarned; set => resourceEarned = value; }    
    public ResourceInfo ResourceSpent { get => resourceSpent; set => resourceSpent = value; }



}
