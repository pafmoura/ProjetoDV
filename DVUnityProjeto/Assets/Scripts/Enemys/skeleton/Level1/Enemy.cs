using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemysInfo enemysInfo;

    private Animator animator;
    private int damage;

    private int life ;
    
    public float attackRadius = 5f;
    public float moveSpeed = 2f;

    private GameObject player;

    private bool isDead;

    private MovementSkeleton movementenemy;

    public HealthBar healthBar;

    [SerializeField] private CharacterStamina characterStamina;

    private SpriteRenderer spriteRenderer;

    private float lastAttackTime = 0f; // tempo do último ataque

    private bool flipped;// inverte a imagem horizontalmente ao mudar de direção
    float ypos;

    void Start()
    {
        ypos=transform.position.y;
        damage= enemysInfo.getDamage();
        life= enemysInfo.getMaxHealth();
        animator= GetComponent<Animator>();


        player = GameObject.FindGameObjectWithTag("Player");

        movementenemy= GetComponent<MovementSkeleton>();

        isDead=false;

        healthBar.SetHealth(life, enemysInfo.getMaxHealth());

        spriteRenderer = GetComponent<SpriteRenderer>();

        flipped=false;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(transform.position.x, 458.974f, transform.position.z);
       //transform.position = new Vector3(transform.position.x, ypos, transform.position.z);
        if (life <= 0){
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
                    
                     if (Time.time - lastAttackTime > enemysInfo.getAttackInterval()) {
                        Attack();
                        lastAttackTime = Time.time;
                    }

                    transform.Translate((player.transform.position - transform.position).normalized * moveSpeed * Time.deltaTime);
                    isnear= true;
                   }
            }
            if(!isnear){
                animator.SetBool("IsCharacterNeer", false);
                movementenemy.playerIsNotNeer();
                lastAttackTime = 0f;
                
                if(flipped){
                    spriteRenderer.flipX = !spriteRenderer.flipX;
                    flipped=false;
                }	


            }

        }

        


    

    public void TakeDamage(int damage){
        life-= damage;
        Debug.Log("Enemy Life: " + life);
        healthBar.SetHealth(life, enemysInfo.getMaxHealth());
    }

    private void Attack(){
        // inverte a imagem horizontalmente ao mudar de direção

        transform.position = new Vector3(transform.position.x, ypos, transform.position.z);
        if (player.transform.position.x > transform.position.x && !flipped && !spriteRenderer.flipX){
            Debug.Log("Flip");
        spriteRenderer.flipX = !spriteRenderer.flipX;
        flipped=true;
        }else if(player.transform.position.x < transform.position.x && !flipped && spriteRenderer.flipX){
            Debug.Log("Flip");
        spriteRenderer.flipX = !spriteRenderer.flipX;
        flipped=true;

            }


        movementenemy.playerIsNeer();
        animator.SetBool("IsCharacterNeer", true);
        characterStamina.TakeDamage(damage);
    }

    //show the radius of attack
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }


}
