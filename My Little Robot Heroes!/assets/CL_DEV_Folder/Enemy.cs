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

    public GameObject CurrentNode = new GameObject();

    public float AllowedDistance;


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
        Vector2 nextPos = this.transform.position - CurrentNode.transform.position;
        transform.position -= (Vector3)(nextPos.normalized * Time.deltaTime * Speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        Debug.Log(nextPos.magnitude);
        if (nextPos.magnitude < AllowedDistance)
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
        if (Health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject core = GameObject.Find("Core");
        GameControl gc = core.GetComponent<GameControl>();
        gc.IncreaseCharge((int)Charge);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hey gotem");
        if (collision.gameObject.tag == "Core")
        {
            Debug.Log("hey gotem");
            dealDamage();
            Destroy(this.gameObject);
        }
    }

    void dealDamage()
    {
        GameObject core = GameObject.FindGameObjectWithTag("Core");
        GameControl gc = core.GetComponent<GameControl>();
        gc.DecreaseHealth((int)this.Damage);
    }


}