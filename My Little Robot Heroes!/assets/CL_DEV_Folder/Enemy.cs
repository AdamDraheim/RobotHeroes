using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float Health = 10f;

    public float Speed = 5f;

    public float Damage = 10f;

    private Transform target;

    private float Charge = 0f;

    private int nextUpdate = 1;

    public GameObject CurrentNode;

    // Start is called before the first frame update
    void Start()
    {
        //target = WayPoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextUpdate)
        {
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            AddCharge();
        }
        Move();
    }

    private void Move()
    {
        Vector3 nextPos = this.transform.position - CurrentNode.transform.position;
        transform.position -= nextPos.normalized * Time.deltaTime * Speed;
        if(nextPos.magnitude < 0.5)
        {
            this.CurrentNode = CurrentNode.GetComponent<Path>().NextNode;
        }
    }

    private void AddCharge()
    {
        Charge += 1f;
    }

    void takeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0) {
            Die();
        }
    }

    void Die()
    {
        //add whatever charge to the charge container 
        //GameObject go = GameObject.Find()
    }

    void dealDamage()
    {
        GameObject core = GameObject.FindGameObjectWithTag("core");
        core.Ge
    }


}
