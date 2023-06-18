using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAll : MonoBehaviour
{
    [SerializeField] private SaveProductionOffline saveProductionOffline;

    [SerializeField] private SaveTroops saveTroops;

    [SerializeField] private JsonUtilitySave jsonUtilitySave;

    public void saveAll(){
        saveProductionOffline.saveAll();
        saveTroops.saveTroops();
        jsonUtilitySave.saveAll();
    }
}
