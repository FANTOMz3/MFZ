using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Maps : MonoBehaviour
{
    public GameObject slot;
    public Vector2Int size = new Vector2Int(15,15); //размер поля в ячейках
    public Vector2 cellSize = new Vector2(5f, 5f); //размер ячейки


    // Start is called before the first frame update
    void Awake()
    {
        size.x = size.x > 50 ? 50 : size.x < 3 ? 3 : size.x;
        size.y = size.y > 50 ? 50 : size.y < 3 ? 3 : size.y;
        
        CreateMap();
    }

    void RemoveAll()
    {
        for (int i = transform.childCount - 1; i > 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }

    private void CreateMap()
    {
        RemoveAll();
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                var instance = Instantiate(slot, transform).transform; //Создание объекта по префабу (slot)
                instance.Translate(cellSize.x * x, 0, cellSize.y * y);
            }
        }
    }

    public void Update()
    {
        CreateMap();
        if (Application.IsPlaying(this)) Destroy(this);
    }
}
