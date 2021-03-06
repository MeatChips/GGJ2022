using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenPatrol : MonoBehaviour
{
    public Transform[] waypoints;
    public int speed;

    private int waypointIndex;
    private float distance;

    Rigidbody m_Rigidbody;



    // Start is called before the first frame update
    void Start()
    {
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);


    }

    // Update is called once per frame
    void Update()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.freezeRotation = true;

        distance = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if(distance < 1f)
        {
            IncreaseIndex();
        }
        Patrol();
    }

    void Patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void IncreaseIndex()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].position);
    }
}
