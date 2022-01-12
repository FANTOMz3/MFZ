using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class MechCanvas : MonoBehaviour
{
    private List<RectTransform> _buttons = new List<RectTransform>();

    private void Awake()
    {
        var parent = transform.GetChild(0);
        for (int i = 0; i < parent.childCount; i++)
        {
            _buttons.Add(parent.GetChild(i).GetComponent<RectTransform>());
        }
        
    }

    public void ToggleUi()
    {
        var inSeq = DOTween.Sequence();
        for (int i = 0; i < _buttons.Count; i++)
        {
            inSeq.Append(_buttons[i].DOLocalMove(new Vector2(-50, -15), 0.2f));
        }

        inSeq.OnComplete(CanvasClose);
    }
    public void CanvasClose()
    {
        var inSeq = DOTween.Sequence();
        foreach (var button in _buttons)
        {
            inSeq.Append(button.DOLocalMove(new Vector2(-100, -100), 0.2f));
        }
    }
}

