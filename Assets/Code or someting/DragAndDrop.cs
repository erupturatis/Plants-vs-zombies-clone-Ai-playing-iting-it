using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public bool MouseHolding = false;
    public int HoldType = 0;

    public Sprite[] Sprites;
    public GameObject ToShow;
    Sprite ToShowS;
    public void StartHolding(int x)
    {
        HoldType = x;
        MouseHolding = true;
        ToShowS = Sprites[HoldType];
        ToShow.SetActive(true);
    }

    public void StopHolding()
    {
        MouseHolding = false;
        ToShow.SetActive(false);
        HoldType = 0;
    }

    void Start()
    {
        ToShow.SetActive(false);
        ToShowS = ToShow.GetComponent<Sprite>();
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            StopHolding();
        }
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        ToShow.transform.position = pos;
    }
}
