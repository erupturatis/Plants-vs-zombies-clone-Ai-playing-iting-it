using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllZombie : MonoBehaviour
{
    public int health = 100;
    public int Type = 0;
    public float Ms = 0;
    public int lane = 0;
    public SpriteRenderer sprite;

    void Start()
    {
        
    }

    public void ChangeSpriteOrder(int x)
    {
        sprite.sortingOrder = x;
        
    }
    public void DecreaseHp(int x)
    {
        health -= x;
    }
    public void Die()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 Pos = new Vector3(-1f,0f,0f);
        transform.position += Pos * Ms * Time.deltaTime;
        if (health <= 0)
        {
            Die();
        }
    }

}
