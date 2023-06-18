using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsShowMenuPort : MonoBehaviour
{
    
    [SerializeField] private GameObject menuPort;
    [SerializeField] private MenuPortUI menuPortUI;

    public void showMenuPort(){
        menuPort.SetActive(true);
        menuPortUI.updateUI();
    }

    
    
}
