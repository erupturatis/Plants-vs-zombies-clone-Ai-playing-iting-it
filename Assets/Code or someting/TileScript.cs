using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public bool HoldingPlant = false;
    int PlantType = 0;
    public int TileNumber = -1;
    DragAndDrop D;
    public GameObject[] plants;
    void Start()
    {
        D = GameObject.FindObjectOfType<DragAndDrop>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Plant(int type)
    {
        HoldingPlant = true;
        GameObject plant = Instantiate(plants[type], transform.position, Quaternion.identity);
        AllPlant A = plant.GetComponent<AllPlant>();
        A.Tile = gameObject;
    }

    void OnMouseDown()
    {
        print("clicked");
        if (HoldingPlant == false && D.MouseHolding == true)
        {
            print("entered ");
            int type = D.HoldType;
            Plant(type);
            D.StopHolding();
        }

    }
}
