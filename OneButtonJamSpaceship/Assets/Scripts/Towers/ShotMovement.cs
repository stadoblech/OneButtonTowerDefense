using UnityEngine;
using System.Collections;

public class ShotMovement : MonoBehaviour {

    public float shotSpeed;

    public Transform target
    {
        get; set;
    }

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (target != null)
            transform.position = Vector3.MoveTowards(transform.position, target.position, shotSpeed * Time.deltaTime);
        else
            Destroy(gameObject);
	}
}
