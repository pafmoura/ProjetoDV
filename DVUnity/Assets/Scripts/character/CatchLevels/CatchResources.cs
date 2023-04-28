using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CatchResources : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Resources resources;
    // Start is called before the first frame update
    void Start()
    {
        resources.resetResorces();
        text.text =  "0/"+ resources.getMaxResources() ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 private void OnTriggerEnter2D(Collider2D collision){

    if(collision.gameObject.tag == "Resources"){
        resources.addResources();
        text.text = resources.getResources()+ "/"+ resources.getMaxResources() ;
        Destroy(collision.gameObject);
    }
 }
}
