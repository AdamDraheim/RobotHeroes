using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject Target;

    public float speed = 0.2f;

    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        Target = FindClosestEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        this.transform.Translate(CalcTrajectory(Target) * speed);
        this.transform.LookAt(Target.transform);

        //this.transform. = CalcTrajectory(Target);
    }

    private Vector3 CalcTrajectory(GameObject Target)
    {
        Vector3 output = new Vector3();

        output.x = Target.transform.position.x - this.transform.position.x;
        output.y = Target.transform.position.y - this.transform.position.y;
        output.z = 0;

        if(Mathf.Sqrt(output.x * output.x + output.y * output.y) <= .5)
        {
            Target.SendMessage("takeDamage", damage);
            Destroy(this.gameObject);
        }

        output.Normalize();

        return output;
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

}