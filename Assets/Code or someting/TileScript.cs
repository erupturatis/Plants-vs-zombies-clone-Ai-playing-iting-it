using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public bool HoldingPlant = false;
    int PlantType = 0;
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

    void OnMouseDown()
    {
        print("clicked");
        if (HoldingPlant == false && D.MouseHolding == true)
        {
            print("entered ");
            HoldingPlant = true;
            int type = D.HoldType;
            GameObject plant = Instantiate(plants[type], transform.position, Quaternion.identity);
            AllPlant A = plant.GetComponent<AllPlant>();
            A.Tile = gameObject;
            D.StopHolding();
        }

    }
}
