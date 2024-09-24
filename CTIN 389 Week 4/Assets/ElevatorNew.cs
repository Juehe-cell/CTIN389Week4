using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorNew : MonoBehaviour
{
    public bool powered;
    public float speed;
    public int startingPoint;
    public Transform[] points;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure startingPoint is within bounds
        if (startingPoint >= 0 && startingPoint < points.Length)
        {
            transform.position = points[startingPoint].position;
            i = startingPoint; // Initialize 'i' with startingPoint
        }
        else
        {
            Debug.LogWarning("Starting point is out of bounds!");
            i = 0; // Fallback to the first point if out of bounds
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (powered)
        {
            // Use Vector3 for position checks
            if (Vector3.Distance(transform.position, points[i].position) < 0.02f)
            {
                i++;
                if (i == points.Length) { i = 0; }
            }

            // Move towards the target position using Vector3
            transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.transform.SetParent(null);
    }
}