using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyManager : MonoBehaviour {
    [SerializeField] Transform[] spawnPoints;
    private GameObject spawn;
    [SerializeField] GameObject enemy;
    int spawnEnemyCount;
    int spawnedEnemies;
    int totalEnemies = 15;
    float count;
    bool canSpawn;
    HUD mHud;
    // Use this for initialization
    void Start () {
        count = Random.Range(0, 5);
        spawnEnemyCount = totalEnemies;
        canSpawn = true;
        mHud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
    }
	
	// Update is called once per frame
	private void Update ()
    {
        IncreaseTime();
        if(spawnEnemyCount == 0)
        {
            Debug.Log("DONE!");
            SceneManager.LoadScene("WinScene");
        }
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
        spawnedEnemies++;
    }

    private void IncreaseTime()
    {
        count += Time.deltaTime;
    }
    
    public void SubtractEnemyCount()
    {
        spawnEnemyCount--;
    }
    public int GetEnemyCount()
    {
        return spawnEnemyCount;
    }
    
}
