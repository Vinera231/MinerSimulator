using UnityEngine;

[CreateAssetMenu(menuName = nameof(PickConfig))]
public class PickConfig : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private PickPurchase _pickPurchase;

    public string Name => _name;

    public string Description => _description;

    public Sprite Icon => _icon;

    public PickPurchase PickPurchase => _pickPurchase;

    public GameObject Prefab => _prefab;
}