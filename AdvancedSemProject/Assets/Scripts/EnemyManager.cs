using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyManager : MonoBehaviour {
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject enemy;
    [SerializeField] int totalEnemies = 5;
    List<GameObject> currentEnemies = new List<GameObject>();
    HUD mHud;
    private GameObject spawn;

    int remainingEnemyCount = 5;
    int spawnedEnemies;
    float count;
    int j = 0;



    // Use this for initialization
    void Start () {
        count = Random.Range(0, 5);
        remainingEnemyCount = totalEnemies;
        mHud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
    }
	
	// Update is called once per frame
	private void Update ()
    {
        IncreaseTime();
        if(count >= 5.0f && spawnedEnemies < totalEnemies)
        {
            Spawning();
            count = Random.Range(0, 5);
        }
	}

    private void Spawning()
    {
        int random = Random.Range(0, spawnPoints.Length);
        spawn = Instantiate(enemy, spawnPoints[random].position, Quaternion.Euler(new Vector3(0, 0, 0)));
        currentEnemies.Add(spawn);
        spawnedEnemies++;
    }

    private void IncreaseTime()
    {
        count += Time.deltaTime;
    }
    
    public void SubtractEnemyCount()
    {
        remainingEnemyCount--;
    }
    public int GetEnemyCount()
    {
        return remainingEnemyCount;
    }

    public List<GameObject> getEnemyList()
    {
         return currentEnemies;
    }
    
}
