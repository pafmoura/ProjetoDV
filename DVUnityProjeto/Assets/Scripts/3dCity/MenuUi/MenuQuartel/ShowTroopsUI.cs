using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ShowTroopsUI : MonoBehaviour
{
    [SerializeField] private TroopsManager troopsManager;


//text to show the number of troops
    [SerializeField] private TextMeshProUGUI numberBig;
    [SerializeField] private TextMeshProUGUI numberLittle;

    void Start()
    {
        updateUI();
    }

    void OnEnable()
    {
        troopsManager.OnTroopChanged += updateUI;
    }
    
    void OnDisable()
    {
        troopsManager.OnTroopChanged -= updateUI;
    }



    private void updateUI()
    {
        numberBig.text = troopsManager.getCurrentTroopBig().ToString();
        numberLittle.text = troopsManager.getCurrentTroopLittle().ToString();
    }
}
