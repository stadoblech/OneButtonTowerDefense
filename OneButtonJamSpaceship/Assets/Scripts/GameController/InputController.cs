using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

    public enum KeycodeStatus
    {
        Pressed,Hold,None
    }

    public KeyCode controllKey = KeyCode.Space;
    public float keyHoldTreshold = 0.3f;
    public static KeycodeStatus keyCodeStatus;

    static float keyholdTime;

    bool holdDown;

	void Start () {
        holdDown = false;
        keyholdTime = 0;
        keyCodeStatus = KeycodeStatus.None;
	}
	
	void Update () {
        
        if(Input.GetKey(controllKey))
        {
            keyholdTime += Time.deltaTime;
            if (keyholdTime > keyHoldTreshold)
            {
                keyCodeStatus = KeycodeStatus.Hold;
            }
        }
        
        if(Input.GetKeyUp(controllKey))
        {
            if(keyholdTime <= keyHoldTreshold)
            {
                keyCodeStatus = KeycodeStatus.Pressed;
            }
        }
	}

    public static void resetKeycodeStatus()
    {
        keyCodeStatus = KeycodeStatus.None;
        keyholdTime = 0;
    }
}
