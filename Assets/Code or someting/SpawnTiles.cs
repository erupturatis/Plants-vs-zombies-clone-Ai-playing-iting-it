using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTiles : MonoBehaviour
{

    [SerializeField] GameObject tile;
    [SerializeField] float distanceX;
    [SerializeField] float distanceY;
    [SerializeField] GameObject StartPos;
    DragAndDrop D;
    void Start()
    {
        D = gameObject.GetComponent<DragAndDrop>();
        float x = StartPos.transform.position.x;
        float y = StartPos.transform.position.y;

        for(int i = 0; i <= 4; i++)
        {
            float xt = x ;
            float yt = y - i * distanceY;
            for(int j = 0; j <= 8; j++)
            {
                Vector3 position = new Vector3(xt, yt, 0f);
                GameObject Tl = Instantiate(tile, position, Quaternion.identity);
                int nr = j + i * 9;
                Tl.GetComponent<TileScript>().TileNumber = nr;
                D.Tiles[nr] = Tl;
                xt += distanceX;
            }
        }
        
    }

 
}
