using UnityEngine;

public class Troop : MonoBehaviour
{
    [SerializeField]private int health = 100;

    [SerializeField] private FeaturesTroop featuresTroop;


    void Start()
    {
        health = featuresTroop.getInicialLife();
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

    public int getHealth(){
        return health;
    }

}
