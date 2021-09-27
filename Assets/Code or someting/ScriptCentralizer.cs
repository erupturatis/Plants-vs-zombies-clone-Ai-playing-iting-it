using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptCentralizer : MonoBehaviour
{
    public SpawnTiles ST;
    public DragAndDrop DD;
    public WaveManager Wm;

    //public GenesManager Gm;

    public AgentBrain Ab;

    public float Fitness = 0;
    public int Nr = 0;
    public int NextLane;

    [HideInInspector]
    public int Suns = 0;

    public Text txt;

    public void Hakai()
    {

        for (int j = 0; j <= 44; j++)
        {
            TileScript Tl = DD.Tiles[j].GetComponent<TileScript>();
            if (Tl.gameObject)
            {
                Destroy(Tl.gameObject);
            }
        }
        GameObject[] Gm = GameObject.FindGameObjectsWithTag("zombie");
        int ln = Gm.Length-1;
        for(int i = 0; i <= ln; i++)
        {
            Destroy(Gm[i]);
        }
        Wm.LaneCounter[0] = 0;
        Wm.LaneCounter[1] = 0;
        Wm.LaneCounter[2] = 0;
        Wm.LaneCounter[3] = 0;
        Wm.LaneCounter[4] = 0;
        Suns = 0;
        Debug.Log("All destroyed");
    }

    public void Die()
    {
        if (Fitness != 0)
        {
            Ab.AddReward(Fitness);
            Fitness = 0;
        }
        //Hakai();
        Ab.EndEpisode();

    }

    private void Start()
    {
        StartCoroutine(AddSuns());
    }

    private void Update()
    {
        if (Fitness != 0)
        {
            Ab.AddReward(Fitness);
            Fitness = 0;
        }
        txt.text = "" + Suns;
    }

    public void PlantOnlane(int x)
    {

        if (Suns >= 100)
        {

            int pos = x * 9;
            for (int j = 0; j <= 8; j++)
            {
                TileScript Tl = DD.Tiles[pos + j].GetComponent<TileScript>();
                if (Tl.HoldingPlant == false)
                {
                    Suns -= 100;
                    Tl.Plant(0);
                    return;
                }
            }
        }
        else
        {
            Ab.AddReward(-0.01f);
        }

    }

    public int[] GetNrZombie()
    {
        return Wm.LaneCounter;

    }
    public int[] GetClosestZombies()
    {
        return new int[5];
    }

    IEnumerator AddSuns()
    {
        yield return new WaitForSeconds(1f);
        Suns += 25;
        StartCoroutine(AddSuns());
    }


}
