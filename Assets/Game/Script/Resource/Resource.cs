using System;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private int _amount;
    [SerializeField] private HealthView _healthView;
    [SerializeField] private ResourceType _resourceType;

    public event Action<ResourceType, int> ResourceDestroyed;

    public ResourceType Type => _resourceType;
    public int Amounts => _amount;

    private void Start()
    {
        _maxHealth = _health;
    }

    public void MineResource(float damage)
    {
        _health -= damage;
        _healthView.ShowHealth(_health, _maxHealth);
    
        if (_health <= 0f)
        {
            ResourceDestroyed?.Invoke(_resourceType,_amount);
            Destroy(gameObject);
        }
    }
}