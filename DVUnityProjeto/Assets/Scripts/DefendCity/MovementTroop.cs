using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTroop : MonoBehaviour
{
    
     
     
     
     [SerializeField] private FeaturesTroop featuresTroop;
   
    [SerializeField]private GameObject targetTroop;
   [SerializeField] private bool isAttacking = false;

    [SerializeField] private bool isDefending = false;
    private string attackTag = "Enemy";


     
     


    void Start()
    {
        if(!isDefending){
            attackTag = "AllyWarrior";
        }

    }   

    
    private void Update()
    {
        if (isAttacking)
            return;


        FindTargetTroop();

        if (targetTroop != null)
        {
            MoveTowardsTarget();
        }
    }

    


    private void MoveTowardsTarget()
    {
        Vector3 targetDirection = targetTroop.transform.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, featuresTroop.getMovementSpeed() * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
        transform.Translate(Vector3.forward * featuresTroop.getMovementSpeed() * Time.deltaTime);
    }


    private void FindTargetTroop()
    {
        GameObject[] troops = GameObject.FindGameObjectsWithTag(attackTag);

        float closestDistance = Mathf.Infinity;
        GameObject closestTroop = null;

        foreach (GameObject troop in troops)
        {
            if (troop == gameObject)
                continue;

            float distance = Vector3.Distance(transform.position, troop.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTroop = troop;
            }
        }

        if (closestTroop != null)
        {
            targetTroop = closestTroop;
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        
        
        
        if (collision.gameObject.CompareTag(attackTag))

        {
            
            
            Troop enemyTroop = collision.gameObject.GetComponent<Troop>();

            if (!isAttacking && enemyTroop != null)
            {
                isAttacking = true;

                Attack(enemyTroop);
            }
        }
    }



  private void Attack(Troop enemyTroop)
    {
        
        
        
        enemyTroop.TakeDamage(featuresTroop.getAttackDamage());
        
        //if the enemy is not dead, attack again
        if (enemyTroop.getHealth() > 0)
        {
            //wait one second and attack again
            Invoke("AttackAgain", 1f);

        }else{

            Invoke("ResetAttack", 0f);
        }
    }


    private void AttackAgain()
    {
        
        if (targetTroop != null)
        {
            // Realiza o ataque novamente
            Attack(targetTroop.GetComponent<Troop>());
        }else {
            // Se o alvo não existe mais, para de atacar
            isAttacking = false;
        }

    }

    
    private void ResetAttack()
    {
        isAttacking = false;
    }


}
