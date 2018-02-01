using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class player : MonoBehaviour {
    
    [Tooltip("In ms^-1")][SerializeField]
    float xspeed = 15f;
    [Tooltip("In ms^-1")][SerializeField]
    float yspeed = 15f;
    [Tooltip("In m")][SerializeField]
    float xrange = 4f;
    [Tooltip("In m")][SerializeField]
    float yrange = 4f;
    [Tooltip("In m")][SerializeField]
    float positionPitchFactor = -5f;
    [Tooltip("In m")][SerializeField]
    float controlPitchFactor = -5f;
    [Tooltip("In m")]
    [SerializeField]
    float positionYawFactor = -5f;
    [Tooltip("In m")]
    [SerializeField]
    float controlYawFactor = -5f;

    float xThrow;
    float yThrow;

	
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ProcessTranslation();
        ProcessRotation();

    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + (yThrow * controlPitchFactor);
        float yaw = transform.localPosition.x * positionYawFactor + (xThrow * controlYawFactor);;
        float roll = 0f;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
         xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * Time.deltaTime * xspeed + transform.localPosition.x;
        float clampedx = Mathf.Clamp(xOffset, -xrange, xrange);
         yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * Time.deltaTime * yspeed + transform.localPosition.y;
        float clampedy = Mathf.Clamp(yOffset, -yrange, yrange);
        transform.localPosition = new Vector3(clampedx, clampedy, transform.localPosition.z);
    }
}
