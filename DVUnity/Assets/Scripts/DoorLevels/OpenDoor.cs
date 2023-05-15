using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    
    private Animator animator;


    public float detectionRadius = 2f;

    private bool playerDetected = false;

    private bool playerIsNear = false;

    [SerializeField]private WinLoseLevel winLevel; 

    public Resources resources;

     void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

         
        playerIsNear = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        foreach (var collider in colliders )
        {
                if(collider.gameObject.tag == "Player"){
                    playerIsNear= true;
                    
                        if(!playerDetected){
                            playerDetected = true;
                          animator.SetBool("PlayerIsNear", true);
        
                            animator.SetTrigger("TriggerOpenDoor");
                        }
                }
        }

        if(!playerIsNear){
            playerDetected = false;
            animator.SetBool("PlayerIsNear", false);
        
        
        }

    }


    //show the overlap circle in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }


    //function trigger colider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            winLevel.WinGame(resources.getResources(), resources.getresourceImage(),resources.getResources().ToString(), resources.getNameOfResource());
        }
        
    }

    
    
}
