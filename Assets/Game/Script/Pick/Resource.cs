using System;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private int _sours;
    [SerializeField] private HealthView _healthView;

    public event Action<int> ResourceDestroyed;

    private void Start()
    {
        _maxHealth = _health;
    }

    public void MineResource(float damage)
    {
        _health -= damage;
        _healthView.ShowHealth(_health, _maxHealth);
    
        if (_health < 0)
        {
            ResourceDestroyed?.Invoke(_sours);
            Destroy(gameObject);
        }

    }
}