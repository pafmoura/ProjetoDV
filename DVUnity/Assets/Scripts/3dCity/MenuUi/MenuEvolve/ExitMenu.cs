using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMenu : MonoBehaviour
{

    [SerializeField] private GameObject menu;
    // Start is called before the first frame update
    public void exitMenu(){
        menu.SetActive(false);
    }
}
