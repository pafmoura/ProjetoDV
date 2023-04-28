using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damageAmount = 10;
    public float attackRadius = 1.5f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            // Encontrar todos os inimigos dentro do raio
            Collider[] colliders = Physics.OverlapSphere(transform.position, attackRadius);

            // Loop através de todos os inimigos encontrados e aplicar dano
            foreach (Collider collider in colliders)
            {
                Enemy enemy = collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damageAmount);
                }
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
