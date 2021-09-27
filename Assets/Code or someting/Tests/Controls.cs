using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float Ms;

    void Start()
    {
        
    }

    public void MoveUp()
    {
        Vector3 dir = new Vector3(0f, 1f, 0f);
        transform.position += dir * Ms * Time.deltaTime;
    }
    public void MoveDown()
    {
        Vector3 dir = new Vector3(0f, -1f, 0f);
        transform.position += dir * Ms * Time.deltaTime;
    }
    public void MoveLeft()
    {
        Vector3 dir = new Vector3(-1f, 0f, 0f);
        transform.position += dir * Ms * Time.deltaTime;
    }
    public void MoveRight()
    {
        Vector3 dir = new Vector3(1f, 0f, 0f);
        transform.position += dir * Ms * Time.deltaTime;
    }

    void Update()
    {
        
        if (Input.GetKey("w"))
        {
            MoveUp();
        }
        if (Input.GetKey("s"))
        {
            MoveDown();
        }
        if (Input.GetKey("a"))
        {
            MoveLeft();
        }
        if (Input.GetKey("d"))
        {
            MoveRight();
        }


    }
}
