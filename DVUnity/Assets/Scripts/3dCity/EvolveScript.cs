using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolveScript : MonoBehaviour
{
    [SerializeField]private LevelBuilds buildlMeshes; 
    // Start is called before the first frame update

    private MeshFilter meshFilter; 


    void Start(){
        buildlMeshes.resetLevel();
        
    }

     public void evolveBuild()
    {
   
        // Delete all existing child game objects
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        //upgrade the level
        buildlMeshes.upgradelevel();
        // Add a new child game object using the specified prefab
        GameObject newChild = Instantiate(buildlMeshes.getLevel(), transform);
        newChild.transform.localPosition = Vector3.zero;
        newChild.transform.localRotation = Quaternion.identity;
    }

  

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
        Invoke("evolveBuild", 1f);
        }
        
    }


    public LevelBuilds getLevelBuilds(){
        return buildlMeshes;
    }


}
