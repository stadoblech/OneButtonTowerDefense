using UnityEngine;
using System.Collections;

public class ObjectRotation : MonoBehaviour {

    public float rotationSpeed;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0,0,rotationSpeed*Time.deltaTime);
	}
}
