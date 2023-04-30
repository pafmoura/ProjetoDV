using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WinLoseLevel : MonoBehaviour
{

    [SerializeField] private ShowMenuCanvas showMenuCanvasWin;
    [SerializeField] private ShowMenuCanvas showMenuCanvasLose;
    [SerializeField] private RawImage rawImage;
    [SerializeField] private TextMeshProUGUI NumberOfResources;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void WinGame(int resources, Texture image, string textResources){
        rawImage.texture = image;
        NumberOfResources.text = textResources;

        disableScriptsOfEnemys();
        showMenuCanvasWin.ShowMenu();

        //disable the player
        gameObject.SetActive(false);

    }


    public void loseGame(){

    
        showMenuCanvasLose.ShowMenu();
        disableScriptsOfEnemys();
        //disable the player
        gameObject.SetActive(false);





    }


private void disableScriptsOfEnemys(){
        
         // Find all objects with the specified tag
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Enemy");

        // Disable all scripts and stop animations on each object with the specified tag
        foreach (GameObject obj in objectsWithTag)
        {
            MonoBehaviour[] scripts = obj.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts)
            {
                script.enabled = false;
            }

            Animator animator = obj.GetComponent<Animator>();
            if (animator != null)
            {
                animator.enabled = false;
            }
        }
    }

}
