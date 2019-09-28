using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower2 : MonoBehaviour
{

    public GameObject bullet;

    public float spawnTime;

    private float delta;

    // Start is called before the first frame update
    void Start()
    {
        delta = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {

        delta -= Time.deltaTime;

        if (delta <= 0)
        {
            delta = spawnTime;

            Instantiate(bullet, this.transform);

        }


    }
}
