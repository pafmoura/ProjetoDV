using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowProductionOffline : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI numberOfWoodMade;
    [SerializeField] private TextMeshProUGUI numberOfRockMade;
    [SerializeField] private TextMeshProUGUI numberOfFoodMade;




    public void showProductionOffline(int woodMade, int rockMade, int foodMade){
        gameObject.SetActive(true);
        numberOfWoodMade.text = woodMade.ToString();
        numberOfRockMade.text = rockMade.ToString();
        numberOfFoodMade.text = foodMade.ToString();
        
    }


    public void funtionButtonLeave(){
        gameObject.SetActive(false);
    }
}
