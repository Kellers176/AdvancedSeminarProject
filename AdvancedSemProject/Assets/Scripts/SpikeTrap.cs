using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour {
    Animator anim;
    // Use this for initialization
    void Start () {
        //anim.
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetPain(int myPain)
    {
        if (myPain == 0)
        {
            anim.SetBool("pain", false);
        }
        else
        {
            anim.SetBool("pain", true);
        }
    }
    
}
