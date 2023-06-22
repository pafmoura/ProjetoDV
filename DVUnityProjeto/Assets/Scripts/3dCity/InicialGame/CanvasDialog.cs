using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CanvasDialog : MonoBehaviour
{
   
   [SerializeField] private DialogsManager dialogsManager;

    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private Image dialogImage;




    private void Start()
    {
        dialogsManager.resetIndex();
    
    }



    public void ShowDialog()
    {
    
        gameObject.SetActive(true);
        dialogText.text = dialogsManager.GetDialog().dialog;
        dialogImage.sprite = dialogsManager.GetDialog().sprite;
    }

    public void NextDialog()
    {
        
        if (dialogsManager.GetDialogsCount()-1 > dialogsManager.GetIndex())
        {
            dialogsManager.incrementIndex();
            dialogText.text = dialogsManager.GetDialog().dialog;
            dialogImage.sprite = dialogsManager.GetDialog().sprite;
        }
        else
        {
            gameObject.SetActive(false);
        }
        
        
    }



}
