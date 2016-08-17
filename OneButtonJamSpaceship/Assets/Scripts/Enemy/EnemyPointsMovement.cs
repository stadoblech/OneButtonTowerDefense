using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPointsMovement : MonoBehaviour {
    public float movingSpeed;
    float resizeOnEndPoint = 3f;
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
                /// 
                if (transform.localScale.x >= 0.2f)
                {
                    float res = transform.localScale.x - resizeOnEndPoint * Time.deltaTime;
                    transform.localScale = new Vector3(res, res);
                }
                

                currentWaypointIndex = waypoints.Count - 1;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position,getNextPosition(),movingSpeed*Time.deltaTime);
        if (transform.localScale.x < 0.2f)
            Destroy(gameObject);
    }

    Vector3 getNextPosition()
    {
        return waypoints[currentWaypointIndex].transform.position;
    }

}
