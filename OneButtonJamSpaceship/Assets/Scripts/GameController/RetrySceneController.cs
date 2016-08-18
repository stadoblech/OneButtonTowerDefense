using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RetrySceneController : MonoBehaviour {

    public KeyCode retryKey = KeyCode.Space;

	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(retryKey))
        {
            SceneManager.LoadScene(GameLogic.actualSceneName);
        }
	}
}
