using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCamera : MonoBehaviour
{
    void Update()
    {
        ScriptCentralizer Sc = GameObject.FindObjectOfType<ScriptCentralizer>();
        if (Sc)
        {
            GameObject Gm = Sc.gameObject;
            gameObject.transform.position = new Vector3(Gm.transform.position.x, Gm.transform.position.y - 4f, -10f);
        }
    }
}
