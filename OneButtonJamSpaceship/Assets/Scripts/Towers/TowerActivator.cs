using UnityEngine;
using System.Collections;

public class TowerActivator : MonoBehaviour {

    public bool towerActivated
    {
        get; set;
    }

    CircleCollider2D coll;
    
    void Awake()
    {
        towerActivated = false;
    }

	void Start () {
        
        coll = GetComponent<CircleCollider2D>();
	}
	
	void Update () {
        coll.enabled = towerActivated;
        
	}

    
}
