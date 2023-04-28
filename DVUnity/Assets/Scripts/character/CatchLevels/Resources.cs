using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "resources", menuName = "Scriptable Objects/Resources")]

public class Resources : ScriptableObject
{
   public int resourcesCatch=0;

    public int MaxResources = 4;


    //get the number of resources
    public int getResources()
    {
         return resourcesCatch;
    }
    //get the max number of resources
    public int getMaxResources()
    {
        return MaxResources;
    }
    

   public void resetResorces()
   {
       resourcesCatch = 0;
   }

   public void addResources()
   {
       resourcesCatch++;
   }
}
