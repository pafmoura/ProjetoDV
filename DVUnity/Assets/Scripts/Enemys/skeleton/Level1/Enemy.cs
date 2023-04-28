using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemysLife enemysLife;

    private Animator animator;
    private int damage;

    private int life ;
    // Start is called before the first frame update
    void Start()
    {
        damage= enemysLife.getDamage();
        life= enemysLife.getLife();
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0){
          //use animation to destroy
            animator.SetTrigger("TriggerIsDead");
        }

        


    }

    public void TakeDamage(int damage){
        life-= damage;
    }


}
