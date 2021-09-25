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
        if (transform.position.x > 10f)
        {
            Destroy(gameObject);
        }
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gm = collision.gameObject;
        if (gm.tag == "zombie")
        {
            AllZombie A = gm.GetComponent<AllZombie>();
            A.DecreaseHp(10);
            Destroy(gameObject);
        }

    }
}
