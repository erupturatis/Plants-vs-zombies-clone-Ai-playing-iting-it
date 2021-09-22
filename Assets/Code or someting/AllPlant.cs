using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPlant : MonoBehaviour
{
    float Health = 100;
    public GameObject Tile;
    TileScript T;
    private void Start()
    {
        if (Tile)
        {
            T = Tile.GetComponent<TileScript>();
            T.HoldingPlant = true;
        }
    }

    public void Die()
    {
        T.HoldingPlant = false;
        Destroy(gameObject);
    }

    private void Update()
    {
        if (Health <= 0)
        {
            Die();
        }
    }

}
