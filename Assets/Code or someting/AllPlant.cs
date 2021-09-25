using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPlant : MonoBehaviour
{
    public float Health = 100;
    public GameObject Tile;
    public TileScript T;
    public WaveManager Wm;
    public ScriptCentralizer Sc;
    private void Start()
    {
        if (Tile)
        {
            T = Tile.GetComponent<TileScript>();
            T.HoldingPlant = true;
            Wm = T.Wm;
        }
    }

    public void Die()
    {
        T.HoldingPlant = false;
        Sc.Fitness -= 10;
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
