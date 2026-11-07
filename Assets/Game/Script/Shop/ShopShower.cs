using UnityEngine;

public class ShopShower : MonoBehaviour
{
    [SerializeField] private ShopPanel _shopPanel;

    public void ShowPanel()
    {
        _shopPanel.Show();
    }
}