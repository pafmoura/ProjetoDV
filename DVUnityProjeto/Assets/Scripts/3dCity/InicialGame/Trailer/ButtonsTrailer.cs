using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsTrailer : MonoBehaviour
{
    [SerializeField] private InicialTrailer inicialTrailer;



    public void skipTrailer(){
        inicialTrailer.skipTrailer();
    }
}
