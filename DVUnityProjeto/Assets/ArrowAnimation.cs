using UnityEngine;

public class ArrowAnimation : MonoBehaviour
{
    public float amplitude = 0.5f;     // The maximum distance the arrow moves up and down.
    public float speed = 1.0f;         // The speed at which the arrow moves.
    private float startX;              // The starting Y position of the arrow.

    void Start()
    {
        startX = transform.position.x; // Store the starting Y position of the arrow.
    }

    void Update()
    {
        // Calculate the new Y position of the arrow based on time.
        float newX = startX + amplitude * Mathf.Sin(speed * Time.time);

        // Update the position of the arrow.
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
