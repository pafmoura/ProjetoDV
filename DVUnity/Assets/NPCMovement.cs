using UnityEngine;
using System.Collections.Generic;

public class NPCMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float stoppingDistance = 350f; 
    public string waypointTag = "waypoint"; 
    public string floorTag = "NPC Floor"; // já n uso

    private List<Transform> waypoints; 
    private int currentWaypointIndex; 
    private RaycastHit hit; 
    private float startY; 

    void Start()
    {
        waypoints = new List<Transform>();
        GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag(waypointTag);
        foreach (GameObject obj in waypointObjects)
        {
            waypoints.Add(obj.transform);
        }
        currentWaypointIndex = Random.Range(0, waypoints.Count);
        startY = transform.position.y;
    }

    void Update()
    {

        Transform currentWaypoint = waypoints[currentWaypointIndex];

        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, startY, transform.position.z);
        if (Vector3.Distance(transform.position, currentWaypoint.position) <= stoppingDistance)
        {
            int randomIndex = Random.Range(0, waypoints.Count);
            currentWaypointIndex = randomIndex;
        }
    }
}
