using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    public Vector2Int pos;
    public Maps map;

    private void OnMouseDown()
    {
        GameManager.NewMech(this);
    }

    public Mech NewMech(GameObject mech)
    {
        if (EventSystem.current.IsPointerOverGameObject()) return null;
        var newMech = Instantiate(mech, transform).GetComponent<Mech>();
        newMech.transform.localPosition = Vector3.up*0.5f;
        return newMech;
    }
}
