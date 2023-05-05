using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ButtonsActions : MonoBehaviour
{

    [SerializeField] private ResourcesManager resourcesManager;


    public void AddWood()
    {
    resourcesManager.addWood(10);
    }

}
