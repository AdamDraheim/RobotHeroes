using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { private set; get; }//Singleton

    public GameObject enemySpawnerPrefab;
    public GameObject spawnLocation;//empty game object placed at location of enemy spawns
    public Transform spawnLocationTransform;

    [Header("Waves")]
    public int waveNumber;
    public bool startNextWave;//true if next wave timer should start
    public float timer;
    public float waveTime;//time until next wave

    private void Awake()
    {
        //Singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //init values
        waveNumber = 1;
        waveTime = 10f;
        spawnLocationTransform = spawnLocation.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startNextWave == true)
        {
            if (timer > waveTime)
            {
                timer = 0f;
                StartNextWave();
            }
            timer += Time.deltaTime;
        }
    }

    /// <summary>
    /// Starts next wave by instantiating a new enemy spawner
    /// </summary>
    public void StartNextWave()
    {
        startNextWave = false;
        Instantiate(enemySpawnerPrefab, spawnLocationTransform);
    }
}
