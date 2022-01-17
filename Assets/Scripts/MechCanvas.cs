using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class MechCanvas : MonoBehaviour
{
    private List<RectTransform> _buttons = new List<RectTransform>();

    [SerializeField] private Vector2 startPos;
    [SerializeField] private float radius;
    [SerializeField] private float angle = .167f;

    public int index;
    
    public bool _iMoving;
    public bool isOpen;

    private void Awake()
    {
        var parent = transform.GetChild(0);
        for (int i = 0; i < parent.childCount; i++)
        {
            _buttons.Add(parent.GetChild(i).GetComponent<RectTransform>());
        }

        index = transform.GetSiblingIndex();
    }

    private void Start()
    {
        UiManager.Instance.uiMech.Add(this);
    }

    public void ToggleUi()
    {
        if (_iMoving) return;
        
        if (isOpen)
        {
            UiManager.CloseAll(index);
        }
        else
        {
            CanvasOpen();
            UiManager.CloseAll(index);
        }
    }

    public void CanvasOpen()
    {
        if (_iMoving) return;

        _iMoving = true;
        var inSeq = DOTween.Sequence();
        for (int i = 0; i < _buttons.Count; i++)
        {
            var _angle = Mathf.PI - angle / 2 + angle * i / (_buttons.Count - 1); // TODO: Исправить баг деления на нуль
            inSeq.Append(_buttons[i]
                .DOLocalMove(startPos + new Vector2(radius * Mathf.Cos(_angle), radius * Mathf.Sin(_angle)), .2f));
        }

        inSeq.OnComplete(() =>
        {
            _iMoving = false;
            isOpen = true;
        });
    }

    public void CanvasClose(bool reverse = false)
    {
        if (_iMoving) return;
        _iMoving = true;
        var inSeq = DOTween.Sequence();
        
        if (reverse) _buttons.Reverse();
        
        foreach (var button in _buttons)
        {
            inSeq.Append(button.DOLocalMove(startPos, .2f));
        }

        inSeq.OnComplete(() =>
        {
            _iMoving = false;
            isOpen = false;
        });
        
        if (reverse) _buttons.Reverse();
    }
}