using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyManager : MonoBehaviour {
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject[] enemy;
    [SerializeField] int totalEnemies;
    int inputEnemy;
    List<GameObject> currentEnemies = new List<GameObject>();
    HUD mHud;
    private GameObject spawn;
    bool stopSpawning;

    int remainingEnemyCount;
    int spawnedEnemies;
    float count;
    int j = 0;

    int wave;
    [SerializeField] int finalWave;



    // Use this for initialization
    void Start () {
        count = Random.Range(0, 5);
        remainingEnemyCount = totalEnemies;
        inputEnemy = totalEnemies;
        mHud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        wave = 1;
        stopSpawning = false;
    }
	
	// Update is called once per frame
	private void Update ()
    {
        Debug.Log(totalEnemies);
        Wave();
	}

    private void Wave()
    {
        IncreaseTime();
        if(count >= 5.0f && spawnedEnemies < totalEnemies && !stopSpawning)
        {
            Spawning();
            count = Random.Range(0, 5);
            if(wave == finalWave && spawnedEnemies >= totalEnemies)
            {
                stopSpawning = true;
            }
        }
        CheckEnemyCount();
    }

    private void CheckEnemyCount()
    {
        if(remainingEnemyCount <= 0 && wave <= finalWave)
        {
            inputEnemy = totalEnemies;
            totalEnemies = inputEnemy + 2;
            remainingEnemyCount = totalEnemies;
            spawnedEnemies = 0;
            wave++;
        }
    }

    private void Spawning()
    {
        int random = Random.Range(0, spawnPoints.Length);
        spawn = Instantiate(enemy[Random.Range(0, enemy.Length)], spawnPoints[random].position, Quaternion.Euler(new Vector3(0, 0, 0)));
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
        Debug.Log(remainingEnemyCount);
    }
    public int GetWaves()
    {
        return wave;
    }
    public int GetEnemyCount()
    {
        return remainingEnemyCount;
    }

    public List<GameObject> getEnemyList()
    {
         return currentEnemies;
    }

    public int getFinalWaveCount()
    {
        return finalWave;
    }
    
}
