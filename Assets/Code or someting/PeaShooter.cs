using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : MonoBehaviour
{
    bool CanShoot = true;
    public GameObject projectile;
    public GameObject Mouth;
    AllPlant Ap;
    WaveManager Wm;
    int lane = 0;
    void Start()
    {
        Ap = gameObject.GetComponent<AllPlant>();
        lane = Ap.T.lane;
        Wm = Ap.Wm;
    }

    void Update()
    {
        if (CanShoot && Wm.LaneCounter[lane]>0)
        {
            CanShoot = false;
            Instantiate(projectile, Mouth.transform.position,Quaternion.identity);
            StartCoroutine(cdr());
        }
        
    }
    IEnumerator cdr()
    {
        yield return new WaitForSeconds(2f);
        CanShoot = true;
    }
}
