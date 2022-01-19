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
    public LayerMask groundLayer;

    // [CanBeNull] public Transform terrain;
    [CanBeNull] public Mech mech;

    private void OnMouseDown()
    {
        GameManager.SlotClick(this);
    }

    public void Start()
    {
        PlaceOnGround();
    }

    public Mech NewMech(GameObject mechPrefab)
    {
        if (EventSystem.current.IsPointerOverGameObject()) return null;
        var newMech = Instantiate(mechPrefab, transform).GetComponent<Mech>();
        newMech.transform.localPosition = Vector3.up*0.5f;
        return newMech;
    }

    private void PlaceOnGround()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit, groundLayer << 8);
        transform.position = hit.point;
    }

    // private void FixedUpdate()
    // {
    //     PlaceOnGround();
    // }
}
