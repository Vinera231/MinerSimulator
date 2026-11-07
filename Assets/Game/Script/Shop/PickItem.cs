using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickItem : MonoBehaviour
{
    private const string RockName = "<sprite name=\"Rock3\">";
    private const string OreName = "<sprite name=\"OreIcon\">";

    [SerializeField] private Image _background;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private TMP_Text _buttonText;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Image _icon;

    [SerializeField] private Color _selectedColor;
    [SerializeField] private Color _notSelectedColor;

    private Action<int> _buttonClicked;
    private int _index;
    private bool _isPurchased;

    private void OnEnable() =>
        _buyButton.onClick.AddListener(OnClick);

    private void OnDisable() =>
        _buyButton.onClick.RemoveListener(OnClick);

    public void Init(int index, PickConfig config, Action<int> buttonClicked)
    {
        _index = index;
        _buttonClicked = buttonClicked;

        _name.text = config.Name;
        _price.text = $"{config.PickPurchase.Amount} {GetIcon(config.PickPurchase.Type)}";
        _icon.sprite = config.Icon;
    }

    public void SetPurchased(bool isPurchased)
    {
        _isPurchased = isPurchased;

        _price.gameObject.SetActive(!isPurchased);

        UpdateButtonText();
    }

    public void SetSelected(bool isSelected)
    {
        _background.color = isSelected ? _selectedColor : _notSelectedColor;

        UpdateButtonText(isSelected);
    }

    private void UpdateButtonText(bool isSelected = false)
    {
        if (isSelected)
            _buttonText.text = "Обраний";
        else
            _buttonText.text = _isPurchased ? "Обрати" : "Купити";
    }

    private string GetIcon(ResourceType resourceType)
    {
        return resourceType switch
        {
            ResourceType.Ore => OreName,
            ResourceType.Rock => RockName,
            ResourceType.None => string.Empty,
            _ => throw new InvalidOperationException("Unknown resource type")
        };
    }

    private void OnClick() =>
        _buttonClicked?.Invoke(_index);
}