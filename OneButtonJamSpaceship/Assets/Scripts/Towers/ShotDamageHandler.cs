using UnityEngine;
using System.Collections;

public class ShotDamageHandler : MonoBehaviour {

    public float DamageDone;

	void Start () {
	
	}


    void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Enemy")
        {
            coll.GetComponent<EnemyLifeHandler>().getHit(DamageDone);
            Destroy(gameObject);
        }
    }
}
