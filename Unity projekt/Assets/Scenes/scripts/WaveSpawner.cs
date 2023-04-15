using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    public int currWave;
    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    public Transform[] spawnLocation; 
    public int spawnIndex;
    public float areaRand;

    public int waveDuration;
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;

    public int antalE;

    public List<GameObject> spawnedEnemies = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GameStart()
    {
        currWave = 0;
        GenerateWave(); 

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (spawnTimer <= 0)
        {
            //spawn an enemy
            if (enemiesToSpawn.Count > 0)
            {
                Vector3 randomPos = spawnLocation[spawnIndex].position + new Vector3(Random.Range(-areaRand, areaRand), 0, Random.Range(-areaRand, areaRand));
                GameObject enemy = (GameObject)Instantiate(enemiesToSpawn[0], randomPos, Quaternion.identity); // spawn first enemy in our list
                enemiesToSpawn.RemoveAt(0); // and remove it
                spawnedEnemies.Add(enemy);
                spawnTimer = spawnInterval;
            }
            else
            {
                waveTimer = 0; // if no enemies remain, end wave
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }

        if (waveTimer <= 0 && spawnedEnemies.Count <= 0)
        {
            currWave++;
            spawnIndex = (spawnIndex + 1) % spawnLocation.Length; // change the spawn index to next in the array 
            GenerateWave();
        }
    }

    public void GenerateWave()
    {
        GenerateEnemies();

        spawnInterval = waveDuration / enemiesToSpawn.Count; // gives a fixed time between each enemies
        waveTimer = waveDuration; // wave duration is read only
    }

    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        for (int i = 0; i < antalE; i++)
        {
            int randEnemyId = Random.Range(0,  enemies.Count);
            generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
        antalE = (int)(antalE * 1.5f);
    }

}

[System.Serializable]
public class Enemy
{
    public GameObject enemyPrefab;
}
