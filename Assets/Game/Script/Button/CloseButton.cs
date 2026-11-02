using System;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    [SerializeField] private ButtonInformer _buttonInformer;
    [SerializeField] private ShopPanel _shopPanel;

    private void OnEnable()
    {
        _buttonInformer.Clicked += OnClick;
    }

    private void OnDisable()
    {
        _buttonInformer.Clicked -= OnClick;
    }

    private void OnClick()
    {
       _shopPanel.Hide();
    }
}