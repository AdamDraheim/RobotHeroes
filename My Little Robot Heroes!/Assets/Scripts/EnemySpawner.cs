using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;//prefab of enemy that this spawner spawns

    public float timer;//timer keeps track of time passed

    public float spawnTime;//time between each enemy spawn
    public float spawnerLevel;//high level spawners spawn enemies faster OR has a longer wave
    public float enemiesForCurrentWave;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        spawnTime = 2f;
        enemiesForCurrentWave = 10 + GameManager.instance.waveNumber * 3; //algorithm to dictate how many enemies spawn for each increasing wave number
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesForCurrentWave > 0)
        {
            if (timer > spawnTime)
            {
                timer = 0f;
                SpawnEnemy();
            }
        }
        else
        {
            //current wave is over, destroys the spawner
            Debug.Log("Wave" + GameManager.instance.waveNumber + "over");
            GameManager.instance.waveNumber++;
            GameManager.instance.startNextWave = true;
            Destroy(gameObject);
        }
        timer += Time.deltaTime;
    }

    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab);
        enemiesForCurrentWave--;
        Debug.Log("spawn enemy" + enemiesForCurrentWave);
    }
}
