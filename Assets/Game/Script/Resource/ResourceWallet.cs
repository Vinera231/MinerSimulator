using UnityEngine;

public class ResourceWallet : MonoBehaviour
{
    [SerializeField] private ViewResourseOre _viewResourseOre;
    [SerializeField] private ViewResourseRock _viewResourseRock;

    private int _rockAmount;
    private int _ironAmount;

    public void AddResource(ResourceType resourceType, int amount)
    {
        if (resourceType == ResourceType.Rock)
            _rockAmount += amount;
        else if (resourceType == ResourceType.Ore)
            _ironAmount += amount;
        else
            return;
  
        UpdateViewResource();
    }

    public int GetAmount(ResourceType resourceType)
    {
        if (resourceType == ResourceType.Rock)
        {
            return _rockAmount;
        }

        if (resourceType == ResourceType.Ore)
        {
            return _ironAmount;
        }

        return 0;
    }

    public bool TrySpend(ResourceType resourceType, int amount)
    {
        if (amount <= 0 || GetAmount(resourceType) < amount)
        {
            return false;
        }

        if (resourceType == ResourceType.Rock)
        {
            _rockAmount -= amount;
        }
        else if (resourceType == ResourceType.Ore)
        {
            _ironAmount -= amount;
        }
        else
        {
            return false;
        }
        UpdateViewResource();
        return true;
    }

    private void UpdateViewResource()
    {
        if(_viewResourseOre != null) 
        _viewResourseOre.OreResourceShow(_ironAmount);

        if (_viewResourseRock != null)
            _viewResourseRock.RockResourceShow(_rockAmount);
    }
}