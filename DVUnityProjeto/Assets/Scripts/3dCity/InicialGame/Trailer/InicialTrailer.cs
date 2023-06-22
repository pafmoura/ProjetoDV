using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class InicialTrailer : MonoBehaviour
{
    
    [SerializeField] private VideoPlayer videoPlayer;


   [SerializeField] private CanvasDialog canvasDialog;

    void Start(){
        videoPlayer.loopPointReached += EndReached;
    }

    public void playTrailer(){
        
        Time.timeScale = 0;
        gameObject.SetActive(true);
        videoPlayer.Play();
    }


    public void skipTrailer(){
        gameObject.SetActive(false);
        videoPlayer.Stop();
        Time.timeScale = 1;
        
        canvasDialog.ShowDialog();
    }


    void EndReached(VideoPlayer vp){
        skipTrailer();
    }


}
