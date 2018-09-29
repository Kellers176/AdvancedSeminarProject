using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayGun : MonoBehaviour {
    Vector2 mouse;
    RaycastHit hit;
    float range = 100.0f;
    LineRenderer line;
    public Material lineMaterial;
	// Use this for initialization
	void Start () {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
        line.GetComponent<Renderer>().material = lineMaterial;
        line.startWidth = 0.1f;
        line.endWidth = 0.25f;
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, range))
        {
            if (Input.GetMouseButtonDown(0))
            {
                line.enabled = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, hit.point + hit.normal);
            }
            else
                line.enabled = false;
        }
	}
}
