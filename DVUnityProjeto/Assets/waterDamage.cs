using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class waterDamage : MonoBehaviour
{

    [SerializeField] private CharacterStamina characterStamina;
    private int waterDmg = 2;

    private bool isDealingDamage = false; 

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isDealingDamage && gameObject.CompareTag("water"))
        {
            StartCoroutine(DealDamageOverTime(other.gameObject));
        }
    }

    IEnumerator DealDamageOverTime(GameObject player)
    {
        isDealingDamage = true;

        while (true)
        {
            if (!player.GetComponent<Collider2D>().IsTouching(GetComponent<Collider2D>()))
            {
                isDealingDamage = false;
                yield break;
            }

            characterStamina.TakeDamage(waterDmg);
            player.GetComponent<Movement>().getPlayerJumpPower();

            yield return new WaitForSeconds(1f);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isDealingDamage)
        {
            StopCoroutine(DealDamageOverTime(other.gameObject));
            isDealingDamage = false;
        }
    }
}
