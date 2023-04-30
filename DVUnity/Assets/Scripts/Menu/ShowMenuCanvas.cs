using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMenuCanvas : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        //disable view of gameObject
        gameObject.SetActive(false);
    }

    //make gameObject visible
    public void ShowMenu()
    {
        gameObject.SetActive(true);
    }
}
