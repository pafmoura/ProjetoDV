using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTimeOpenGame : MonoBehaviour
{
    
    // check if the directory save data have someting in it
    // if not, then it's the first time the game is open
    // so we need to show the dialog


   [SerializeField] private CanvasDialog canvasDialog;


    [SerializeField] private InicialTrailer inicialTrailer;

   public void isTheFirstTimeOpenGame(){
       canvasDialog.ShowDialog();
       inicialTrailer.playTrailer();


   } 


   
    
    
}
