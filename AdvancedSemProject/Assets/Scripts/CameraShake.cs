using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
	private Transform cameraTransform;
	private float shakeDuration = 0f;
	private float shakeMagnitude = 0.1f;
	private float dampingSpeed = 2.0f;
	Vector3 initialPosition;


	// Use this for initialization
	void Awake () {
		cameraTransform = GetComponent<Transform>();
		initialPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		Shake();
	}


	void Shake()
	{
		if(shakeDuration > 0)
		{
			transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
			shakeDuration -= Time.deltaTime * dampingSpeed;
		}
		else
		{
			shakeDuration = 0;
			transform.localPosition = initialPosition;
		}


	}

	public void TriggerShake()
	{
		shakeDuration = 0.3f;
	}
}
