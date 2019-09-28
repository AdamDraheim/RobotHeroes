using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Attach to empty player object
//Button: button for tower to create
//Obj: tower to place
public class TowerSpawn : MonoBehaviour
{
    public GameObject button;
    public GameObject obj;
    private GameObject clone;

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

        try
        {
            //Gets half width and height of object
            float w = button.GetComponent<Renderer>().bounds.size.x / 2;
            float h = button.GetComponent<Renderer>().bounds.size.y / 2;

            //Get current x y position of object
            float posNowX = button.transform.position.x;
            float posNowY = button.transform.position.y;

            //if mouse within bounds of object
            if (pos.x > posNowX - w && pos.x < posNowX + w && pos.y > posNowY - h && pos.y < posNowY + h)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    pos = new Vector3(posNowX, posNowY, 0);
                    //create tower
                    clone = Instantiate(obj, pos, Quaternion.identity);
                }
                //if mouse position within bounds of button on mouse button up
                if (Input.GetMouseButtonUp(0))
                {
                    //-change this when menus and levels exist-
                    if (pos.x > posNowX - w && pos.x < posNowX + w && pos.y > posNowY - h && pos.y < posNowY + h)
                    {
                        //destroy the tower
                        Destroy(clone);
                    }
                }
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

}
