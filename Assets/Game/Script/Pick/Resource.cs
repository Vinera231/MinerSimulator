using System;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private int _sours;

    public event Action<int> ResourceDestroyed;
    public void MineResource(float damage)
    {
        _health -= damage;

        if(_health < 0)
        {
            Destroy(gameObject);
            ResourceDestroyed.Invoke(_sours);
        }
    }
}