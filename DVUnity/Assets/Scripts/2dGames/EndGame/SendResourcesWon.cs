using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class SendResourcesWon : MonoBehaviour
{
    public void sendResources(int numberOfResources, string nameOfResource){
        
        string filePath = Application.dataPath + "/SaveData/Resources.json"; // Caminho do arquivo JSON 




        if (File.Exists(filePath))
        {


            Debug.Log("File Existscxsacdascss");
            string json = File.ReadAllText(filePath); // Lê o conteúdo do arquivo JSON

            // Converte o JSON para um objeto Unity
            SaveResourcesData resources = JsonUtility.FromJson<SaveResourcesData>(json);


            updateResource(nameOfResource, numberOfResources, resources);
            
        }
    }



    
    private void updateResource(string nameOfResource, int resources, SaveResourcesData resourcesData){
        if(nameOfResource=="wood"){
            resourcesData.wood+= resources;
            saveResources(resourcesData);
        }else if(nameOfResource=="rock"){
            resourcesData.rock+=resources;
            saveResources(resourcesData);
        }else if(nameOfResource=="food"){
            resourcesData.food+= resources;
            saveResources(resourcesData);
        }
    }


    private void saveResources(SaveResourcesData resourcesData){
        string json = JsonUtility.ToJson(resourcesData); // Converte o objeto Unity para JSON
        string filePath = Application.dataPath + "/SaveData/Resources.json"; // Caminho do arquivo JSON 
        File.WriteAllText(filePath, json); // Escreve o JSON no arquivo
    }
}





public class SaveResourcesData{
    public int wood;
    public int rock;
    public int food;
}
