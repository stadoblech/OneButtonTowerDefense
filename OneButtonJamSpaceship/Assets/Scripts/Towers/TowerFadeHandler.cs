using UnityEngine;
using System.Collections;

public class TowerFadeHandler : MonoBehaviour {

    public float fadeSpeed;

    SpriteRenderer sr;
    float fadeValue;

	void Start () {
        fadeValue = 0;
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Color32(255,255,255,0);
        StartCoroutine(wallFade(gameObject));
        
    }
	
	void Update () {
    }

    IEnumerator wallFade(GameObject o)
    {
        while (fadeValue < 1f)
        {
            fadeValue += fadeSpeed * Time.deltaTime;
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, fadeValue);
            o.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, fadeValue);
            yield return null;
        }
    }
}
