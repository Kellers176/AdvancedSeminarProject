using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour {
    [SerializeField] EnemyManager myEnemyManager;
    [SerializeField] GameObject oldSprite;
    bool done = false;

    // Use this for initialization
    private void Start () {
    }
	
	// Update is called once per frame
	private void Update ()
    {
        CheckEnemyCount();
    }

    private void CheckEnemyCount()
    {
        if(myEnemyManager.GetEnemyCount() == 0)
        {
            oldSprite.SetActive(false);
            done = true;
        }
    }

    public bool getDone()
    {
        return done;
    }
}
