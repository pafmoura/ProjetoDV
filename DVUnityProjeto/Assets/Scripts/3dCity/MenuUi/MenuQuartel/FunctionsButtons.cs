using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionsButtons : MonoBehaviour
{


    [SerializeField] private GameObject menuProduceTroops;
    [SerializeField] private TroopsUI troopsUI;

    
    

    public void goToMenuProduceTroops(){
        menuProduceTroops.SetActive(true);
        troopsUI.updateAllUI();
    
    }
}
