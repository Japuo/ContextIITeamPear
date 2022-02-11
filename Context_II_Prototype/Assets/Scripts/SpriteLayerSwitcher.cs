using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLayerSwitcher : MonoBehaviour
{
    public float relativeY = 0;
    SpriteRenderer sr;
    int layerDefault;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        layerDefault = sr.sortingOrder;
    }

    private void Update()
    {
        if(Player.Instance.transform.position.y > transform.position.y + relativeY)
        {
            sr.sortingOrder = -layerDefault;
        }
        else
        {
            sr.sortingOrder = layerDefault;
        }    
    }
}
