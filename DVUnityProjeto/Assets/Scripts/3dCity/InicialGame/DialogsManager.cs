using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DialogsManager", menuName = "Scriptable Objects/DialogsManager")]
public class DialogsManager : ScriptableObject
{





    [SerializeField] private List<Dialog> dialogs = new List<Dialog>();

    [SerializeField] private int index = 0;





    public Dialog GetDialog()
    {
        return dialogs[index];
    }



    public int GetDialogsCount()
    {
        return dialogs.Count;
    }

    public void incrementIndex()
    {
        index++;
    }

    public void resetIndex()
    {
        index = 0;
    }


    public int GetIndex()
    {
        return index;
    }



 
}



