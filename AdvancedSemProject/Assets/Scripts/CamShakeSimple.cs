using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShakeSimple : MonoBehaviour {

		Vector3 originalPosition;

		float shakeAmount = 0;

		[SerializeField] Camera mainCamera;
	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CameraShake()
	{
		if(shakeAmount > 0)
		{
			float moveAmount = Random.value * shakeAmount * 2 - shakeAmount;
			Vector3 cameraPosition = mainCamera.transform.position;
			cameraPosition.y += moveAmount;
			mainCamera.transform.position = cameraPosition;
		}
	}

	void StopShaking()
	{
		CancelInvoke("CameraShake");
		mainCamera.transform.position = originalPosition;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		shakeAmount = col.relativeVelocity.magnitude * .0025f;
		InvokeRepeating("CameraShake", 0, .01f);
		Invoke("StopShaking", 0.3f);
	}

}
