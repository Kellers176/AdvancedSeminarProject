using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionStay2D(Collision2D col)
	{
		Destroy(col.gameObject);
	}
	private void OnTriggerStay2D(Collider2D col)
	{
		Destroy(col.gameObject);
	}
}
