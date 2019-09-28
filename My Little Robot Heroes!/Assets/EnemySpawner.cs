using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;//prefab of enemy that this spawner spawns
    public float timer;//timer keeps track of time passed
    public float spawnTime;//time between each enemy spawn

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        spawnTime = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > spawnTime)
        {
            timer = 0f;
            SpawnEnemy();
        }
        timer += Time.deltaTime;
    }

    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab);
        Debug.Log("spawn enemy");
    }
}
