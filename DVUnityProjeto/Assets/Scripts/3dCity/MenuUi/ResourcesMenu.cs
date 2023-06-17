using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ResourcesMenu : MonoBehaviour
{

    [SerializeField]public ResourcesManager resourcesManager;

    //references to the text objects of resources
    [SerializeField] private TextMeshProUGUI woodText;
    [SerializeField] private TextMeshProUGUI rockText;
    [SerializeField] private TextMeshProUGUI foodText;


    void Start()
    {
        //update the text of the resources
        updateAllResourcesText();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnEnable()
    {
       /*
        resourcesManager.OnResourceWoodChanged += UpdateWoodText;
        
        resourcesManager.OnResourceRockChanged += UpdateRockText;
        
        resourcesManager.OnResourceFoodChanged += UpdateFoodText;
*/
        resourcesManager.OnWoodCountChanged += UpdateWoodText;
        resourcesManager.OnRockCountChanged += UpdateRockText;
        resourcesManager.OnFoodCountChanged += UpdateFoodText;

        
        

    }

    private void OnDisable()
    {/*
        resourcesManager.OnResourceWoodChanged -= UpdateWoodText;
        resourcesManager.OnResourceRockChanged -= UpdateRockText;
        resourcesManager.OnResourceFoodChanged -= UpdateFoodText;
*/
        resourcesManager.OnWoodCountChanged -= UpdateWoodText;
        resourcesManager.OnRockCountChanged -= UpdateRockText;
        resourcesManager.OnFoodCountChanged -= UpdateFoodText;

    }

 



    //methods to update the text of the resources
    public void UpdateWoodText()
    {
        woodText.text = resourcesManager.getWood().ToString();
    }
    public void UpdateRockText()
    {
        rockText.text = resourcesManager.getRock().ToString();
    }
    public void UpdateFoodText()
    {
        foodText.text = resourcesManager.getFood().ToString();
    }


   private void updateAllResourcesText()
    {
        UpdateWoodText();
        UpdateRockText();
        UpdateFoodText();
    }





}
