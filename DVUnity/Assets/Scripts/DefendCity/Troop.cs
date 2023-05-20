using UnityEngine;

public class Troop : MonoBehaviour
{
    public float movementSpeed = 2f;
    public int attackDamage = 10;
    public int health = 100;

    [SerializeField]private GameObject targetTroop;
    private bool isAttacking = false;

    [SerializeField] private bool isDefending = false;
    private string attackTag = "EnemyTroop";

    void Start()
    {
        if(!isDefending){
            attackTag = "DefendingTroop";
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
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, movementSpeed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
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
                Attack(enemyTroop);
            }
        }
    }

    private void Attack(Troop enemyTroop)
    {
        isAttacking = true;

        
        
        // Implementar a lógica de ataque aqui
        enemyTroop.TakeDamage(attackDamage);
        
        //if the enemy is not dead, attack again
        if (enemyTroop.health > 0)
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
        }

    }


    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Implementar a lógica de quando a tropa morre
        Destroy(gameObject);
    }

    private void ResetAttack()
    {
        isAttacking = false;
    }
}
