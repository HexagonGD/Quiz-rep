using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RestartUI : MonoBehaviour
{
    [SerializeField] private Color _firstColor;
    [SerializeField] private Color _secondColor;
    private Image _image;

    [SerializeField] private UnityEvent Restart;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        _image.color = Color.clear;
        _image.DOColor(_firstColor, 1f);
    }

    public void RestartGame()
    {
        _image.DOColor(_secondColor, 1f).OnComplete(() =>
        _image.DOColor(Color.clear, 1f).OnComplete(() =>
        {
            gameObject.SetActive(false);
            Restart?.Invoke();
        }));
    }
}
