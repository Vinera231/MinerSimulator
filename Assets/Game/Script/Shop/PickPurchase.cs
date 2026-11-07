using System;
using UnityEngine;

[Serializable]
public class PickPurchase
{
    [SerializeField] private int _amount;
    [SerializeField] private ResourceType _type;

    public int Amount => _amount;
    public ResourceType Type => _type;
}