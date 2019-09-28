using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public Text health;
    public Text charge;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health.text = GameControl.gameControl.Gethealth() + " healthpoints";
        charge.text = GameControl.gameControl.GetCharge() + " charge";
    }
}
