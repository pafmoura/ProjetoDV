using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ShowUI : MonoBehaviour
{
    [SerializeField] private TroopsManager troopsManager;


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


    void updateUI()
    {
        numberBig.text = troopsManager.getCurrentTroopBig().ToString()+ "/" + troopsManager.getMaxTroopBig().ToString();
        numberLittle.text = troopsManager.getCurrentTroopLittle().ToString() + "/" + troopsManager.getMaxTroopLittle().ToString();
    }



}
