using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileScript : MonoBehaviour
{
    public bool HoldingPlant = false;
    int PlantType = 0;
    public int TileNumber = -1;
    public int ZombiesStanding = 0;
    public DragAndDrop D;
    public GameObject[] plants;
    public int lane = 0;
    public WaveManager Wm;
    public ScriptCentralizer Sc;
    public Text txt;


    // Update is called once per frame
    void Update()
    {
        txt.text = "" + ZombiesStanding;
    }

    public void Plant(int type)
    {
        Sc = Wm.Sc;
        HoldingPlant = true;
        GameObject plant = Instantiate(plants[type], transform.position, Quaternion.identity);
        AllPlant A = plant.GetComponent<AllPlant>();
        A.Sc = Sc;
        A.Tile = gameObject;
        //Sc.Fitness += 20f;
        plant.transform.parent = gameObject.transform;
    }

    void OnMouseDown()
    {

        if (HoldingPlant == false && D.MouseHolding == true)
        {

            int type = D.HoldType;
            Plant(type);
            D.StopHolding();
        }

    }
}
