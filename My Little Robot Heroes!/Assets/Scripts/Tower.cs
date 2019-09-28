using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Vector3 pos;
    private bool set;
    public GameObject obj;
    private GameObject clone;

    // Start is called before the first frame update
    void Start()
    {
        pos = Input.mousePosition;
        pos += new Vector3(0, 0, 10);
        set = false;
    }

    // Update is called once per frame
    void Update()
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0) && set == false)
        {
            pos += new Vector3(0, 0, 10);
            transform.position = pos;
        }

        if(Input.GetMouseButtonUp(0))
        {
            set = true;
        }

        menu();
    }

    //Creates an upgrades? menu at the tower position
    void menu()
    {
        //Gets half width and height of object
        float w = GetComponent<Collider>().bounds.size.x / 2;
        float h = GetComponent<Collider>().bounds.size.y / 2;

        //Get current x y position of object
        float posNowX = transform.position.x;
        float posNowY = transform.position.y;

        //if mouse within bounds of object
        if (pos.x > posNowX - w && pos.x < posNowX + w && pos.y > posNowY - h && pos.y < posNowY + h)
        {
            //If tower set and menu doesn't exist
            if (set == true && clone == null)
            {
                //if left mouse click
                if (Input.GetMouseButton(0))
                {
                    //Creates object with top left corner centred on object
                    pos += new Vector3(0, 0, 10);
                    Vector3 v = new Vector3(posNowX + w, posNowY - h * 2, 0);
                    clone = Instantiate(obj, v, Quaternion.identity);
                }
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                Destroy(clone);
            }
        }
    }
}
