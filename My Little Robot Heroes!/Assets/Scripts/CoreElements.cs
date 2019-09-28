using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CoreElements : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "enemy")
        {
            Destroy(coll.gameObject);
            GameControl.gameControl.DecreaseHealth(1);
            Debug.Log(GameControl.gameControl.Gethealth());
        }
    }

}
  
}

