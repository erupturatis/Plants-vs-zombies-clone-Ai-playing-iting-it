using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCentralizer : MonoBehaviour
{
    public SpawnTiles ST;
    public DragAndDrop DD;
    public WaveManager Wm;

    public GenesManager Gm;

    public float Fitness = 0;
    public int Nr = 0;
    public int NextLane;

    public void Die()
    {
        Gm.SetDeath(Nr,Fitness);
        Destroy(gameObject);
    }

    private void Start()
    {
        Gm = GameObject.FindObjectOfType<GenesManager>();
        StartCoroutine(Dye());
    }
    private void Update()
    {
        NextLane = Gm.NextLane;
        //print(NextLane);
    }

    public float[] GetTileZombieStatus()
    {
        float[] zomb = new float[46];
        for(int i = 0; i <= 44; i++)
        {
            GameObject Gm = DD.Tiles[i];
            TileScript T = Gm.GetComponent<TileScript>();
            zomb[i] = (float)T.ZombiesStanding;
        }
        return zomb;
    }
    IEnumerator Dye()
    {
        yield return new WaitForSeconds(120f);
        Die();
    }

}
