using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : MonoBehaviour
{
    bool CanShoot = true;
    public GameObject projectile;
    public GameObject Mouth;
    void Start()
    {
        
    }

    void Update()
    {
        if (CanShoot)
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
