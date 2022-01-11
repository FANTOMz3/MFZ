using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechCanvas : MonoBehaviour
{
    public void toggleUI()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
