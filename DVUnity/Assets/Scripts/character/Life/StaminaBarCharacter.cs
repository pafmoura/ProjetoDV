using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBarCharacter : MonoBehaviour
{

    public HealthBar healthBar;
    [SerializeField] private CharacterStamina characterStamina;
   
    // Start is called before the first frame update
    void Start()
    {
    
    characterStamina.resetStamina();
    healthBar.SetHealth(characterStamina.getStamina(), characterStamina.getMaxStamina());  
    }

    // Update is called once per frame
    void Update()
    {

       if(characterStamina.getStamina() <= 0){
        characterStamina.resetStamina();
        healthBar.SetHealth(characterStamina.getStamina(), characterStamina.getMaxStamina());  
        Destroy(gameObject, 4f);
        //use animation to destroy
       /*  if(!isDead){
         animator.SetTrigger("TriggerIsDead");
         Destroy(gameObject, 4f);
         isDead=true;
         }*/
         return;
    
    }

    healthBar.SetHealth(characterStamina.getStamina(), characterStamina.getMaxStamina());  

 
        
    }
}
