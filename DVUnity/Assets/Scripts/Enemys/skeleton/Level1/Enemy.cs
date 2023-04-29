using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemysLife enemysLife;

    private Animator animator;
    private int damage;

    private int life ;
    
    public float attackRadius = 5f;
    public float moveSpeed = 2f;

    private GameObject player;

    private bool isDead;

    private MovementSkeleton movementenemy;

    public HealthBar healthBar;
    void Start()
    {
        damage= enemysLife.getDamage();
        life= enemysLife.getMaxHealth();
        animator= GetComponent<Animator>();


        player = GameObject.FindGameObjectWithTag("Player");

        movementenemy= GetComponent<MovementSkeleton>();

        isDead=false;

        healthBar.SetHealth(life, enemysLife.getMaxHealth());
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0){
          //use animation to destroy
            if(!isDead){
            animator.SetTrigger("TriggerIsDead");
            Destroy(gameObject, 4f);
            isDead=true;
            }
            return;
        }

            bool isnear = false;
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackRadius);

            foreach(Collider2D hitCollider in hitColliders) {
                
                

                if (hitCollider.gameObject.tag == "Player") {
                    Attack();
                    transform.Translate((player.transform.position - transform.position).normalized * moveSpeed * Time.deltaTime);
                    isnear= true;
                   }
            }
            if(!isnear){
                animator.SetBool("IsCharacterNeer", false);
                movementenemy.playerIsNotNeer();
            }

        }

        


    

    public void TakeDamage(int damage){
        life-= damage;
        Debug.Log("Enemy Life: " + life);
        healthBar.SetHealth(life, enemysLife.getMaxHealth());
    }

    private void Attack(){
        movementenemy.playerIsNeer();

        animator.SetBool("IsCharacterNeer", true);
    }

    //show the radius of attack
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }


}
