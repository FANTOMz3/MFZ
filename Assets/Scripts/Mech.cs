using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Mech : MonoBehaviour
{
    public String name = "Mech";

    public MechCanvas myMenu;

    [SerializeField] private Text serialNumber;

    private void Start()
    {
        var serialNumberInt = Random.Range(0, 999999);
        var serialNumberString = (6 - serialNumberInt.ToString().Length) * '0' + serialNumberInt.ToString();
        SetName($"Mech №{serialNumberString}");
    }

    public void SetName(string newName)
    {
        name = newName;
        serialNumber.text = name;
        myMenu.UpdateName();
    }
    
    private void OnMouseDown()
    {
        myMenu.ToggleUi();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void Move(Slot slot)
    {
        if (slot.mech != null) return;
        
        transform.SetParent(slot.transform);
        slot.mech = this;

        // var origRot = transform.rotation;
        // transform.LookAt(new Vector3(slot.transform.position.x, 2, slot.transform.position.z), Vector3.left);
        // var newRot = transform.rotation;
        // transform.rotation = origRot;

        var moveSeq = DOTween.Sequence();
        // moveSeq.Append(transform.DORotate(newRot.eulerAngles, 1f));
        moveSeq.Append(transform.DOLocalMove(Vector3.up * 0.5f, 1f).SetEase(Ease.Linear));
    }
}
