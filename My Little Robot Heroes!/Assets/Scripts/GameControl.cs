using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{

    public static GameControl gameControl;


    private int charge;
    private int health;
    [Range(1, int.MaxValue)]
    public int startHealth = 20;
    [Range(0, int.MaxValue)]
    public int startCharge = 100;


    // Start is called before the first frame update
    void Start()
    {

        //Make this a singleton
        if(gameControl != null)
        {
            //Destroy(this.gameObject);
        }
        else
        {
            gameControl = this.gameObject.GetComponent<GameControl>();
            DontDestroyOnLoad(this.gameObject);
        }
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        this.health = this.startHealth;
        this.charge = this.startCharge;
    }

    public int GetCharge()
    {
        return this.charge;
    }

    /**
     * If the user has enough charge, return true and decrease charge by the requested amount. Else return false
     * */
    public bool UseCharge(int chargeUsed)
    {
        if(this.charge - chargeUsed >= 0)
        {
            this.charge -= chargeUsed;
            return true;
        }
        return false;
    }

    public void IncreaseCharge(int increase)
    {
        this.charge += increase;
    }

    /**
     * Checks if there is greater than or equal to the requested charge amount
     * */
    public bool CompareCharge(int chargeComp)
    {
        return this.charge >= chargeComp;
    }

    public void DecreaseHealth(int dec)
    {
        this.health -= dec;
    }

    public int Gethealth()
    {
        return this.health;
    }

    private void CheckHealth()
    {
        if(this.health <= 0)
        {
            int i = 0;
            int w = i / 0;
        }
    }

}
