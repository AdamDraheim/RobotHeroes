using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTower : MonoBehaviour
{
    public GameObject tower;
    public int towerCost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos = new Vector3(pos.x, pos.y, 0);
        if (Input.GetMouseButtonDown(0))
        {
            if(GameControl.gameControl.UseCharge(towerCost)){
                GameObject.Instantiate(tower, pos, Quaternion.identity);
            }
        }
    }
}
