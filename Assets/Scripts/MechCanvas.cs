using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MechCanvas : MonoBehaviour
{
    public Mech myMech;

    private List<RectTransform> _buttons = new List<RectTransform>();

    [SerializeField] private Vector2 startPos;
    [SerializeField] private float radius;
    [SerializeField] private float angle = .167f;

    private Animation myAnim;

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
        myAnim = transform.GetComponent<Animation>();
    }

    private void Start()
    {
        UiManager.Instance.uiMech.Add(this);
    }

    #region Animation

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

        ButtonsSetActive(true);
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
            ButtonsSetActive(false);
        });

        if (reverse) _buttons.Reverse();
    }

    #endregion

    #region Destroy

    private void ButtonsSetActive(bool state)
    {
        foreach (var b in _buttons)
        {
            b.gameObject.SetActive(state);
        }
    }

    public void Destroy()
    {
        myAnim.Play("Mech control OFF");
        StartCoroutine(DestroyInSecond());
    }

    private IEnumerator DestroyInSecond()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    #endregion

    public void UpdateName()
    {
        transform.GetComponentInChildren<Text>().text = myMech.name;
    }
}