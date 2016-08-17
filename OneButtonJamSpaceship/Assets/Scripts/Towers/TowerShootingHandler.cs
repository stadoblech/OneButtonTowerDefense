using UnityEngine;
using System.Collections;

public class TowerShootingHandler : MonoBehaviour {

    public GameObject shoot;
    public float shootingCooldown;
    public float shotSpeed;
    public float shotDamage;

    float shootTimer;

    bool onTowerRange;

    void Start () {
        onTowerRange = false;
        shootTimer = 0;
	}
	
	void Update () {
        if(shootTimer <= 0 && onTowerRange)
        {
            shootTimer = shootingCooldown;
        }
        shootTimer -= Time.deltaTime;
	}

    void OnTriggerStay2D(Collider2D coll)
    {
        onTowerRange = true;
        if (coll.tag == "Enemy" && shootTimer <= 0)
        {
            GameObject o = (GameObject)Instantiate(shoot,transform.position,Quaternion.identity);
            o.GetComponent<ShotMovement>().target = coll.transform;
            o.GetComponent<ShotMovement>().shotSpeed = this.shotSpeed;
            o.GetComponent<ShotDamageHandler>().DamageDone = shotDamage;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Enemy")
        {
            onTowerRange = false;
        }
    }
}
