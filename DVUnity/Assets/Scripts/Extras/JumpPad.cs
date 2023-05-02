using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float impulsionForce = 5f; // The amount of force that will be applied to the player


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 impulsionDirection = transform.up; // Use the pad's up direction to calculate the force direction
                rb.AddForce(impulsionDirection * impulsionForce, ForceMode2D.Impulse); // Apply the impulsion force to the player
            }
        }
    }
}
