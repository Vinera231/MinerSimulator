using UnityEngine;

public class ResourceWallet : MonoBehaviour
{
    [SerializeField] private ViewResourseOre _viewResourseOre;
    [SerializeField] private ViewResourseRock _viewResourseRock;
    [SerializeField] private ViewResourseCoal _viewResourseCoal;

    private int _rockAmount;
    private int _ironAmount;
    private int _coalAmount;

    private void Start()
    {
        SaveData saveData = Save.LoadGame();

        _rockAmount = saveData.RockAmount;
        _ironAmount = saveData.OreAmount;
        _coalAmount = saveData.CoalAmount;

        UpdateViewResource();
    }

    public void AddResource(ResourceType resourceType, int amount)
    {
        switch (resourceType)
        {
            case ResourceType.Rock: _rockAmount += amount; break;
            case ResourceType.Ore: _ironAmount += amount; break;
            case ResourceType.Coal: _coalAmount += amount; break;
            case ResourceType.None: return;
        }

        SaveResource();
        UpdateViewResource();
    }

    public int GetAmount(ResourceType resourceType) =>
        resourceType switch
        {
            ResourceType.Rock => _rockAmount,
            ResourceType.Ore => _ironAmount,
            ResourceType.Coal => _coalAmount,
            _ => 0
        };


    public bool TrySpend(ResourceType resourceType, int amount)
    {
        if (amount <= 0 || GetAmount(resourceType) < amount)
            return false;

        switch (resourceType)
        {
            case ResourceType.Rock: _rockAmount -= amount; break;
            case ResourceType.Ore: _ironAmount -= amount; break;
            case ResourceType.Coal: _coalAmount -= amount; break;
            default: return false;
        }

        SaveResource();
        UpdateViewResource();
        return true;
    }

    private void UpdateViewResource()
    {
        if (_viewResourseOre != null)  _viewResourseOre.OreResourceShow(_ironAmount);
          
        if (_viewResourseRock != null)  _viewResourseRock.RockResourceShow(_rockAmount);
          
        if (_viewResourseCoal != null) _viewResourseCoal.CoalResourceShow(_coalAmount);      
    }

    public void SaveResource()
    {
        SaveData saveData = Save.LoadGame();

        saveData.RockAmount = _rockAmount;
        saveData.OreAmount = _ironAmount;
        saveData.CoalAmount = _coalAmount;

        Save.SaveGame(saveData);
    }
}