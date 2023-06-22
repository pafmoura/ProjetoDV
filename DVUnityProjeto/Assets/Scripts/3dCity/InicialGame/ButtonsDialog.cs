using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsDialog : MonoBehaviour
{
    

    [SerializeField] private CanvasDialog canvasDialog;
    public void doNextDialog()
    {
       canvasDialog.NextDialog();
        
        
        
    }


}
