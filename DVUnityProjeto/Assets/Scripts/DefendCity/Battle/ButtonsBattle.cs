using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ButtonsBattle : MonoBehaviour
{
    
    public void goToCity(){
        
        Time.timeScale = 1;
        SceneManager.LoadScene("Village Level");
    }
}
