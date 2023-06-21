using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog 
{

    public string dialog;
    public Sprite sprite;

    public Dialog(string dialog, Sprite sprite)
    {
        this.dialog = dialog;
        this.sprite = sprite;
    }
    
    
}
