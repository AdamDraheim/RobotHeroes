using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawn : MonoBehaviour
{
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        place();
    }

    void place()
    {
        Vector3 pos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos += new Vector3(0, 0, 10);

        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(obj, pos, Quaternion.identity);
        }

    }

}
