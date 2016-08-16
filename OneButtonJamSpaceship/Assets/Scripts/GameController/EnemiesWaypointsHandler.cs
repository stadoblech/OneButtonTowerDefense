﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemiesWaypointsHandler : MonoBehaviour {

    public GameObject enemyToSpawn;
    public int numberOfEnemiesToSpawn;
    public float startRoundTime;
    public float enemySpawnCooldown;
    public float enemySpeed;

    List<Transform> points;

    Transform spawnPoint;
    Transform endPoint;

    void Start () {
        points = new List<Transform>();
        foreach(Transform t in transform)
        {
            points.Add(t);
        }

        spawnPoint = points[0];
        endPoint = points[points.Count - 1];

        if(spawnPoint == endPoint)
        {
            enabled = false;
            throw new System.Exception("There is only one enemies waypoints. Add more waypoints");
        }

        StartCoroutine(spawnEnemies(startRoundTime));
    }
	
    IEnumerator spawnEnemies(float t)
    {
        yield return new WaitForSeconds(t);
        numberOfEnemiesToSpawn--;
        if(numberOfEnemiesToSpawn < 0)
        {
            yield break;
        }
        GameObject o = (GameObject)Instantiate(enemyToSpawn, spawnPoint.transform.position, Quaternion.identity);
        EnemyPointsMovement movement = o.GetComponent<EnemyPointsMovement>();
        movement.waypoints = points;
        movement.lastWaypoint = endPoint;
        movement.movingSpeed = enemySpeed;

        StartCoroutine(spawnEnemies(enemySpawnCooldown));
    }
	// Update is called once per frame
	void Update () {
	    
	}
}
