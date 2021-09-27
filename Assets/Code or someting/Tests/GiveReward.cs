using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveReward : MonoBehaviour
{
    public MoveToGoal Mg;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "reward")
        {
            GameObject Gm = collision.gameObject;
            float X = Random.Range(-3.5f, 3.5f);
            float Y = Random.Range(-3.5f, 3.5f);
            Vector3 pos = new Vector3(X, Y, 0f);
            Mg.AddRw(1f);
            Mg.EndEpis();
            Gm.transform.localPosition = pos;
        }else
        if(collision.gameObject.tag == "wall")
        {
            Mg.AddRw(-1f);
            Mg.EndEpis();
        }
    }
}
