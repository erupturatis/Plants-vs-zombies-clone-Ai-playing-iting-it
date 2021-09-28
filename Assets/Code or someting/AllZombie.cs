using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllZombie : MonoBehaviour
{
    public int health = 20;
    public int Type = 0;
    public float Ms = 0;
    public int lane = 0;
    public float factor = 2;
    public SpriteRenderer sprite;
    public WaveManager Wm;
    public TileScript CurrentTile;
    public ScriptCentralizer Sc;

    float DisFromStart;
    public float StartX;

    [HideInInspector]
    public float moved = 0f;

    float MsCopy;

    void Start()
    {
        MsCopy = Ms;   
    }

    public void ChangeSpriteOrder(int x)
    {
        sprite.sortingOrder = x;
        
    }
    public void DecreaseHp(int x)
    {
        health -= x;
        //print(health);
    }
    public void Die()
    {
        Sc = Wm.Sc;
        Sc.Fitness += 10;
        Wm.LaneCounter[lane] -= 1;
        if (CurrentTile)
        {
            CurrentTile.ZombiesStanding -= 1;
        }
        
        Destroy(gameObject);
    }
    public void Death()
    {
        Wm.LaneCounter[lane] -= 1;
        if (CurrentTile)
        {
            CurrentTile.ZombiesStanding -= 1;
        }
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
        moved = StartX - transform.position.x;
        if (moved > 14f)
        {
            Sc.Fitness = -1000;
            Sc.Die();
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject Gm = collision.gameObject;
        if (Gm.tag == "tile")
        {
            if (CurrentTile)
            {
                CurrentTile.ZombiesStanding -= 1;
            }
            TileScript T = Gm.GetComponent<TileScript>();
            CurrentTile = T;
            CurrentTile.ZombiesStanding += 1;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject Gm = collision.gameObject;
        if( Gm.tag == "plant")
        {
            AllPlant A = Gm.GetComponent<AllPlant>();
            A.Health -= Time.deltaTime*factor;
            Ms = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Ms = MsCopy;
    }

}
