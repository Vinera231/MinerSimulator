using System.Collections.Generic;
using UnityEngine;

public class ShopInitializer : MonoBehaviour
{
    [SerializeField] private PickItem _prefab;
    [SerializeField] private Transform _content;
    [SerializeField] private PickConfig[] _pickConfigs;

    [SerializeField] private ResourceWallet _resourceWallet;
    [SerializeField] private PickSwitcher _pickSwitcher;

    private readonly List<PickItem> _items = new();

    private int _selectedIndex = -1;
    private bool _initialized;

    public IReadOnlyList<PickItem> Items => _items;

    private void Awake() => Init();

    public void Init()
    {
        if (_initialized)
            return;

        if (_prefab == null)
        {
            return;
        }

        if (_content == null)
        {
            return;
        }

        if (_resourceWallet == null)
        {
            return;
        }

        if (_pickSwitcher == null)
        {
            return;
        }

        if (_pickConfigs == null || _pickConfigs.Length == 0)
        {
            return;
        }

        _initialized = true;

        ClearContent();
        _pickSwitcher.Initialize();

        int count = Mathf.Min(_pickConfigs.Length, _pickSwitcher.Count);

        for (int i = 0; i < count; i++)
        {
            PickConfig config = _pickConfigs[i];

            if (config == null)
                continue;

            PickItem item = Instantiate(_prefab, _content);
            item.gameObject.SetActive(true);

            item.Init(i, config, OnPickButtonClicked);

            bool isPurchased = _pickSwitcher.IsPurchased(i);

            item.SetPurchased(isPurchased);
            item.SetSelected(false);

            _items.Add(item);
        }

        if (_items.Count > 0)
            Select(0);
    }

    private void OnPickButtonClicked(int index)
    {
        if (index < 0 || index >= _pickConfigs.Length)
            return;

        if (_pickSwitcher.IsPurchased(index))
        {
            SelectPick(index);
            return;
        }

        TryPurchase(index);
    }

    private void TryPurchase(int index)
    {
        PickPurchase purchase = _pickConfigs[index].PickPurchase;

        if (purchase == null)
            return;

        if (!_resourceWallet.TrySpend(purchase.Type, purchase.Amount))
        {
            Debug.Log("Not enough resources!");
            return;
        }

        if (!_pickSwitcher.UnlockAndSelect(index))
        {
            Debug.LogError("Failed to unlock pick!");
            return;
        }

        _items[index].SetPurchased(true);

        Select(index);

        Debug.Log("Pick purchased!");
    }

    private void SelectPick(int index)
    {
        if (!_pickSwitcher.UseItem(index))
            return;

        Select(index);
    }

    private void Select(int index)
    {
        if (index < 0 || index >= _items.Count)
            return;

        if (_selectedIndex >= 0)
            _items[_selectedIndex].SetSelected(false);

        _selectedIndex = index;
        _items[_selectedIndex].SetSelected(true);
    }

    private void ClearContent()
    {
        foreach (Transform child in _content)
        {
            Destroy(child.gameObject);
        }

        _items.Clear();
        _selectedIndex = -1;
    }
}