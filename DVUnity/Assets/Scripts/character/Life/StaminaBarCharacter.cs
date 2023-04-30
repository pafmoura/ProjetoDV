using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StaminaBarCharacter : MonoBehaviour
{

    public HealthBar healthBar;
    [SerializeField] private CharacterStamina characterStamina;
   
    private bool isDead;
    private Animator animator;
    private Rigidbody2D rb;

    [SerializeField] private WinLoseLevel winLoseLevel;

    // Start is called before the first frame update
    void Start()
    {

    characterStamina.resetStamina();
    healthBar.SetHealth(characterStamina.getStamina(), characterStamina.getMaxStamina());  
    isDead=false;
    animator= GetComponent<Animator>();
    rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

       if(characterStamina.getStamina() <= 0){

        if(!isDead){
            
            

            healthBar.SetHealth(characterStamina.getStamina()  , characterStamina.getMaxStamina());  

            animator.SetTrigger("TriggerIsDead");
             isDead=true;
            rb.gravityScale = 0 ;



            disableAll();



            //wait for 5 seconds
            StartCoroutine(showMenu(5f));


            return;
         }

        if(isDead){
            return;
        }

        characterStamina.resetStamina();
        healthBar.SetHealth(characterStamina.getStamina(), characterStamina.getMaxStamina());  

        //use animation to destroy
        
    
    }

    healthBar.SetHealth(characterStamina.getStamina(), characterStamina.getMaxStamina());  

 
        
    }

private void disableAll(){
    // Disable all scripts on this GameObject
        MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {   
            //check if the script is the stamina bar script
            if(script == GetComponent<WinLoseLevel>()){
                continue;
            }
            script.enabled = false;
        }


        //disable rigidbody and collider
        rb.gravityScale = 0 ;
        Collider2D collider = GetComponent<Collider2D>();
        collider.enabled = false;
}


  IEnumerator showMenu(float delay)
    {
        yield return new WaitForSeconds(delay);

            //disable script of the enemy
        
            winLoseLevel.loseGame();
        }

        

}

