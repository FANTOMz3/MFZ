using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject prototypePrefab;

    [CanBeNull] public Mech mechToMove;

    private void Awake()
    {
        Instance = this;
    }

    public static void SetMechToMove(Mech mech)
    {
        Instance.mechToMove = mech;
    }

    public static void NewMech(Slot slot)
    {
        var newMech = slot.NewMech(Instance.prototypePrefab);
        if (newMech is null) return;
        UiManager.NewMech(newMech);
    }

    public static void DestroyMech(Mech removedMech)
    {
        if (Instance.mechToMove == removedMech) Instance.mechToMove = null;
        UiManager.RemoveMech(removedMech);
        removedMech.Destroy();
    }

    public static void SlotClick(Slot slot)
    {
        if (Instance.mechToMove != null) {
            Instance.mechToMove.Move(slot);
            Instance.mechToMove = null; 
            return;}
        if (slot.mech == null) {NewMech(slot);}
    }

}
