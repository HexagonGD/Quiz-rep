using UnityEngine;
using DG.Tweening;
using System;

public class Cell : MonoBehaviour
{
    [SerializeField] private Item _item;
    [SerializeField] private SpriteRenderer _itemRenderer;
    private bool _isAnimation;

    public Action<Cell> Click;
    public Action AnimationEnd;

    public string Identifier => _item.Identifier;

    public void SetItem(Item item)
    {
        _item = item;
        _itemRenderer.sprite = item.Sprite;
    }

    public void DoShake()
    {
        if (_isAnimation) return;
        _isAnimation = true;
        _itemRenderer.transform.DOShakePosition(0.5f, new Vector3(0.5f, 0, 0), randomness: 0).OnComplete(() => OnAnimationEnd());
    }

    public void DoBounce()
    {
        if (_isAnimation) return;
        _isAnimation = true;
        transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0), 1f, vibrato: 3, elasticity: 0.6f).OnComplete(() => OnAnimationEnd());
    }

    public void DoBounceItem()
    {
        if (_isAnimation) return;
        _isAnimation = true;
        _itemRenderer.transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0), 1f, vibrato: 3, elasticity: 0.6f).OnComplete(() => OnAnimationEnd());
    }

    private void OnMouseDown()
    {
        Click?.Invoke(this);
    }

    private void OnAnimationEnd()
    {
        _isAnimation = false;
        AnimationEnd?.Invoke();
    }
}