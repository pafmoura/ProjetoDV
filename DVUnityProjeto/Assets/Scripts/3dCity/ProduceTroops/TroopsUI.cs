using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TroopsUI : MonoBehaviour
{
    [SerializeField] private TroopsManager troopsManager;

    [SerializeField] private LevelBuilds townHall;

    [SerializeField] private LevelBuilds quartel;



    //fields ui troops
    [SerializeField] private TextMeshProUGUI woodCostLittle;
    [SerializeField] private TextMeshProUGUI rockCostLittle;
    [SerializeField] private TextMeshProUGUI foodCostLittle;


    [SerializeField] private TextMeshProUGUI woodCostBig;
    [SerializeField] private TextMeshProUGUI rockCostBig;
    [SerializeField] private TextMeshProUGUI foodCostBig;


    [SerializeField] private TextMeshProUGUI numberOfTroopsLittle;
    [SerializeField] private TextMeshProUGUI numberOfTroopsBig;

    [SerializeField] private GameObject panelHideTroopBig;


    void Start()
    {
        troopsManager.updateAll();
        updateUI();
        updateNumberOfTroops();
        isToHideTroopBig();
    }


    private void isToHideTroopBig()
    {
        if (quartel.getNumberLevel() < 2)
        {
            panelHideTroopBig.SetActive(true);
        }
        else
        {
            panelHideTroopBig.SetActive(false);
        }
    }





    public void updateAllUI()
    {
        troopsManager.updateAll();
        updateUI();
        updateNumberOfTroops();
        isToHideTroopBig();
    }


    void OnEnable()
    {
        townHall.OnBuildLevelChanged += troopsManager.updateAll;
        troopsManager.OnTroopChanged += updateNumberOfTroops;
    }

    void OnDisable()
    {
        townHall.OnBuildLevelChanged -= troopsManager.updateAll;
        troopsManager.OnTroopChanged -= updateNumberOfTroops;
        
    }


    private void updateUI()
    {
        woodCostLittle.text = troopsManager.getWoodCostLittle().ToString();
        rockCostLittle.text = troopsManager.getRockCostLittle().ToString();
        foodCostLittle.text = troopsManager.getFoodCostLittle().ToString();

        woodCostBig.text = troopsManager.getWoodCostBig().ToString();
        rockCostBig.text = troopsManager.getRockCostBig().ToString();
        foodCostBig.text = troopsManager.getFoodCostBig().ToString();

    }

    private void updateNumberOfTroops()
    {
        numberOfTroopsLittle.text = troopsManager.getCurrentTroopLittle().ToString()+ "/"+troopsManager.getMaxTroopLittle().ToString();
        numberOfTroopsBig.text = troopsManager.getCurrentTroopBig().ToString()+ "/"+troopsManager.getMaxTroopBig().ToString();
     
    }



}
