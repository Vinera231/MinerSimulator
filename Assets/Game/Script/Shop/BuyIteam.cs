using UnityEngine;
using System;

public class BuyIteam : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private ChangePick _changePick;
    [SerializeField] private ResourceType _resource;
    [SerializeField] private PickSwitcher _pickSwitcher;
    [SerializeField] private ResourceWallet _resourceWallet;
    [SerializeField] private ButtonInformer _buttonInformer;
    [SerializeField] private GameObject _pick;
    [SerializeField] private GameObject _panel;

    public event Action<GameObject> Buyed;

    private void OnEnable()
    {
        _buttonInformer.Clicked += OnClick;
    }
    private void OnDisable()
    {
        _buttonInformer.Clicked -= OnClick;
    }

    public void OnClick()
    {
        TryBuy();
    }

    public bool TryBuy()
    {
        if (_pick == null || _changePick == null || _resourceWallet == null)
            return false;

        if (!_resourceWallet.TrySpend(_resource, _price))
            return false;


        _changePick.CurrentPick(_pick);
        _pickSwitcher.Change();
        Buyed?.Invoke(_pick);

        if (_panel != null)
            _panel.SetActive(false);

        return true;
    }
}
