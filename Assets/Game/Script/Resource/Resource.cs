using System;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private string _id;
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private int _amount;
    [SerializeField] private HealthView _healthView;
    [SerializeField] private ResourceType _resourceType;

    public event Action<ResourceType, int> ResourceDestroyed;

    private void Start()
    {
        _maxHealth = _health;

        if (string.IsNullOrEmpty(_id))
            _id = $"{gameObject.scene.name}_{transform.position.x:F2}_{transform.position.y:F2}";

        SaveData saveData = Save.LoadGame();
        if (saveData.MinedResources !=null && saveData.MinedResources.Contains(_id))
        {
            Destroy(gameObject);
            return;
        }
    }

    public void MineResource(float damage)
    {
        _health -= damage;
        _healthView.ShowHealth(_health, _maxHealth);
    
        if (_health <= 0f)
        {
            ResourceDestroyed?.Invoke(_resourceType, _amount);
            SaveMiner();
            Destroy(gameObject);
        }
    }

    private void SaveMiner()
    {
       SaveData saveData = Save.LoadGame();

        if (saveData.MinedResources == null)
            saveData.MinedResources = new List<string>();

        if (!saveData.MinedResources.Contains(_id))
            saveData.MinedResources.Add(_id);

        Save.SaveGame(saveData);
    }
}
