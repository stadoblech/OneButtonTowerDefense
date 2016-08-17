using UnityEngine;
using System.Collections;

public class TowerActivator : MonoBehaviour {

    public float towerLiveExpectation;

    public bool towerActivated
    {
        get; set;
    }

    CircleCollider2D coll;

    float toweLifeSpan;

    void Awake()
    {
        towerActivated = false;
    }

    void Start()
    {
        coll = GetComponent<CircleCollider2D>();
        toweLifeSpan = towerLiveExpectation;
    }
	void Update () {
        coll.enabled = towerActivated;
        /*
        if(towerActivated)
        {
            toweLifeSpan -= Time.deltaTime;
            if(toweLifeSpan <= 0)
            {
                towerActivated = false;
                foreach(Transform t in transform)
                {
                    Destroy(t.gameObject);
                }
                toweLifeSpan = towerLiveExpectation;
            }
            
        }
        */
	}

    
}
