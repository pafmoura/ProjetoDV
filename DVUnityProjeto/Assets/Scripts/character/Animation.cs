using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   void Update ()
 { 
    if (Input.GetKeyDown(KeyCode.A))
    {
        GetComponent<Animator>().SetTrigger("TriggerRunning");
    }
    if (Input.GetKeyUp(KeyCode.A))
    {
        GetComponent<Animator>().SetTrigger("TriggerIdle");
    }
   
    if (Input.GetKeyDown(KeyCode.D))
    {
        GetComponent<Animator>().SetTrigger("TriggerRunning");
    }
    if (Input.GetKeyUp(KeyCode.D))
    {
        GetComponent<Animator>().SetTrigger("TriggerIdle");
    }

    if(Input.GetKeyDown(KeyCode.K)){
        GetComponent<Animator>().SetTrigger("TriggerAttack");
    }
    if(Input.GetKeyUp(KeyCode.K)){
        GetComponent<Animator>().SetTrigger("TriggerIdle");
    }
   

    
    


 }

}
