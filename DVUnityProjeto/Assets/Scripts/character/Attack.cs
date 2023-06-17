using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attackRadius = 2f;
    public int attackDamage = 20;

    void Update () {
        if (Input.GetKeyDown(KeyCode.K)) {
            AttackEnemy();
        }
    }

    void AttackEnemy() {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackRadius);
        foreach(Collider2D hitCollider in hitColliders) {
            if (hitCollider.gameObject.tag == "Enemy") {
                Enemy enemy = hitCollider.gameObject.GetComponent<Enemy>();
                enemy.TakeDamage(attackDamage);
            }
        }
    }

    //show the radius of attack
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
