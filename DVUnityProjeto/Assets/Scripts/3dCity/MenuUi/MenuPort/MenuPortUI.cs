using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuPortUI : MonoBehaviour
{
    
    [SerializeField] private ProduceClicks produceClicks;

    [SerializeField] private TextMeshProUGUI woodProduceByClick;
    [SerializeField] private TextMeshProUGUI rockProduceByClick;
    [SerializeField] private TextMeshProUGUI foodProduceByClick;





    //method called when open the menu
    public void updateUI(){
        woodProduceByClick.text = "+ "+produceClicks.getWoodProduce().ToString();
        rockProduceByClick.text = "+ "+produceClicks.getRockProduce().ToString();
        foodProduceByClick.text = "+ "+produceClicks.getFoodProduce().ToString();
    }

}
