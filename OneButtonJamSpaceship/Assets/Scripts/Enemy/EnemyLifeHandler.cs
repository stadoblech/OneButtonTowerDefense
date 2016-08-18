using UnityEngine;
using System.Collections;

public class EnemyLifeHandler : MonoBehaviour {

    public float life;

    Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {

        if(life <= 0)
        {
            Destroy(gameObject);
        }
	}

    public void getHit(float hitAmount)
    {
        if(life > 0)
        {
            transform.localScale -= new Vector3(resizeOnDmg(hitAmount), resizeOnDmg(hitAmount));
        }
        life -= hitAmount;
    }

    public float resizeOnDmg(float dmg)
    {
        float downSide = life * originalScale.x;
        return (float)(dmg / downSide);
    }

    
}
