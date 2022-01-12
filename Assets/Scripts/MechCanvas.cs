using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MechCanvas : MonoBehaviour
{
    public void toggleUI()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
    public void canvasoff()
    {
        if (gameObject.activeSelf == true)
        {
            gameObject.SetActive(false);
        }
    }
    public void buttonmove()
    {
        
    }
}
