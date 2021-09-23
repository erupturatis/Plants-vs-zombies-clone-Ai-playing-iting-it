using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float MovementSpeed;

    void Update()
    {
        Vector3 pos = new Vector3(MovementSpeed, 0f, 0f) * Time.deltaTime;
        transform.position += pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("triggered collison");
        GameObject gm = collision.gameObject;
        if (gm.tag == "zombie")
        {
            print("e zombie");
            AllZombie A = gm.GetComponent<AllZombie>();
            A.DecreaseHp(10);
            Destroy(gameObject);
        }

    }
}
