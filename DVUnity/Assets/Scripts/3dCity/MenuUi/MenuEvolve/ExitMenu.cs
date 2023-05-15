using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMenu : MonoBehaviour
{

    [SerializeField] private GameObject menu;

    [SerializeField] private GameObject resoucesProduction;
    // Start is called before the first frame update
    public void exitMenu(){
        menu.SetActive(false);
        resoucesProduction.SetActive(false);
    }
}
