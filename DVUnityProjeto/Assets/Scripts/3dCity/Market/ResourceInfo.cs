using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceInfo  
{
        [SerializeField] private Sprite resourceImage;
        [SerializeField] private ResourceEnum resourceType;


        public Sprite ResourceImage { get => resourceImage; set => resourceImage = value; }
        public ResourceEnum ResourceType { get => resourceType; set => resourceType = value; }

        


}


