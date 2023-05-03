using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownHallScript : MonoBehaviour
{
    [SerializeField]private LevelBuilds thownHallMeshes; 
    // Start is called before the first frame update

    private MeshFilter meshFilter; 

     public void Upgradelevel()
    {
   
        // Delete all existing child game objects
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        //upgrade the level
        thownHallMeshes.Upgradelevel();
        // Add a new child game object using the specified prefab
        GameObject newChild = Instantiate(thownHallMeshes.GetLevel(), transform);
        newChild.transform.localPosition = Vector3.zero;
        newChild.transform.localRotation = Quaternion.identity;
    }

    void Update(){
        Invoke("ReplaceChildrenWithNew", 5f);
    }


}
