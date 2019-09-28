using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Vector3 pos;
    private bool set;
    
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
        
    }
}
