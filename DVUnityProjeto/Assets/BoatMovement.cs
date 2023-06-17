using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public float speed = 2f;  // The speed at which the boat moves
    public float distance = 2f;  // The distance the boat travels in its loop

    private Vector3 initialPosition;  // The initial position of the boat

    private bool goingForward = true;  // Flag to indicate whether the boat is moving forward or backward

    void Start()
    {
        initialPosition = transform.position;  // Set the initial position of the boat
    }

    void Update()
    {
        // Move the boat back and forth along its Z-axis
        float step = speed * Time.deltaTime;

        if (goingForward)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition + Vector3.forward * distance, step);
            if (transform.position.z >= initialPosition.z + distance)
            {
                goingForward = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, step);
            if (transform.position.z <= initialPosition.z)
            {
                goingForward = true;
            }
        }
    }
}
