using NUnit.Framework;
using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public int RockAmount;
    public int OreAmount;
    public int CoalAmount;

    public bool[] PurchasedPick;
    public int PurchasedPickCount;

    public List<string> MinedResources = new List<string>();
}