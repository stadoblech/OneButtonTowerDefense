using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPointsMovement : MonoBehaviour {
    public float movingSpeed;
    public List<Transform> waypoints
    {
        get; set;
    }
    public Transform lastWaypoint
    {
        get; set;
    }
    int currentWaypointIndex;

	void Start () {
        currentWaypointIndex = 0;    
	}
	
	void Update () {
        if (waypoints[currentWaypointIndex].transform.position == transform.position)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex > waypoints.Count-1)
            {
                /// HERE IS HIT
                Destroy(gameObject);
                currentWaypointIndex = waypoints.Count - 1;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position,getNextPosition(),movingSpeed*Time.deltaTime);
    }

    Vector3 getNextPosition()
    {
        return waypoints[currentWaypointIndex].transform.position;
    }

}
