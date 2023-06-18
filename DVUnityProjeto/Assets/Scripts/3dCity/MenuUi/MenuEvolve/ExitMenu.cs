using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMenu : MonoBehaviour
{

    [SerializeField] private GameObject menu;

    [SerializeField] private GameObject resoucesProduction;

    [SerializeField] private GameObject menuQuartel;

    [SerializeField] private GameObject menuPort;

    [SerializeField] private GameObject menuMarket;

    // Start is called before the first frame update
    public void exitMenu(){
        menu.SetActive(false);
        resoucesProduction.SetActive(false);
        menuQuartel.SetActive(false);
        menuPort.SetActive(false);
        menuMarket.SetActive(false);
    }



    public void exitMenuTroops(){
        menuQuartel.SetActive(false);
    }

}
