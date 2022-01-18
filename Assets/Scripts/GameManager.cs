using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject prototypePrefab;

    private void Awake()
    {
        Instance = this;
    }

    public static void NewMech(Slot slot)
    {
        var newMech = slot.NewMech(Instance.prototypePrefab);
        if (newMech is null) return;
        UiManager.NewMech(newMech);
    }

    public static void DestroyMech(Mech mech)
    {
        var menu = mech.myMenu;
        menu.Destroy();
        mech.Destroy();
    }


}
