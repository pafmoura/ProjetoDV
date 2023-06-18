using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonShowMenu : MonoBehaviour
{
    
    [SerializeField] private GameObject menu;
    [SerializeField] private ShowMenuMarket menuUI;

    public void showMenu(){
        menu.SetActive(true);
        menuUI.updateUI();
    }
}
