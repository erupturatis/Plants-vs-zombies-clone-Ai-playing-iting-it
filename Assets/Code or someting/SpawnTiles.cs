using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTiles : MonoBehaviour
{

    [SerializeField]  GameObject tile;
    [SerializeField]  float distanceX;
    [SerializeField]  float distanceY;
    [SerializeField]  GameObject StartPos;
    void Start()
    {
        float x = StartPos.transform.position.x;
        float y = StartPos.transform.position.y;

        for(int i = 0; i <= 4; i++)
        {
            float xt = x ;
            float yt = y - i * distanceY;
            for(int j = 1; j <= 9; j++)
            {
                Vector3 position = new Vector3(xt, yt, 0f);
                Instantiate(tile, position, Quaternion.identity);
                xt += distanceX;
            }
        }
        
    }

 
}
