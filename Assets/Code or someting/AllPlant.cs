using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPlant : MonoBehaviour
{
    public float Health = 200;
    public GameObject Tile;
    public TileScript T;
    public WaveManager Wm;
    public ScriptCentralizer Sc;
    public int Lane = 0;
    private void Start()
    {
        if (Tile)
        {
            T = Tile.GetComponent<TileScript>();
            T.HoldingPlant = true;
            Wm = T.Wm;
            Lane = T.lane;
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
