using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WipeAllZombies : MonoBehaviour
{

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "zombie")
        {
            collision.gameObject.GetComponent<AllZombie>().Death();
        }
    }
}
