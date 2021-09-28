using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public float timePause = 2f;
    bool CanSpawn = true;
    public GameObject[] zombies;
    public GameObject SpawnPoint;
    public ScriptCentralizer Sc;
    [HideInInspector]
    public int DestroyAll = 0;
    public int[] LaneCounter = new int[5];
    

    void Update()
    {
        if (CanSpawn)
        {
            CanSpawn = false;
            int lane = Random.Range(0, 5);
            
                    
            Vector3 pos = new Vector3(SpawnPoint.transform.position.x , SpawnPoint.transform.position.y + lane * -1.55f, 0f);
            GameObject zombie = Instantiate(zombies[0],pos,Quaternion.identity);
            AllZombie A = zombie.GetComponent<AllZombie>();
            A.ChangeSpriteOrder(lane+1);
            A.lane = lane;
            A.Wm = GetComponent<WaveManager>();
            A.StartX = SpawnPoint.transform.position.x;
            A.transform.parent = Sc.gameObject.transform;
            A.Sc = Sc;
            LaneCounter[lane] += 1;
            StartCoroutine(Pause());
        }
        
    }
    IEnumerator Pause()
    {
        yield return new WaitForSeconds(timePause+3f);
        CanSpawn = true;
    }

}
