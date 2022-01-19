using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    public Vector2Int pos;
    public Maps map;

    // [CanBeNull] public Transform terrain;
    [CanBeNull] public Mech mech;

    private void OnMouseDown()
    {
        GameManager.SlotClick(this);
    }

    public Mech NewMech(GameObject mechPrefab)
    {
        if (EventSystem.current.IsPointerOverGameObject()) return null;
        var newMech = Instantiate(mechPrefab, transform).GetComponent<Mech>();
        newMech.transform.localPosition = Vector3.up*0.5f;
        return newMech;
    }
}
