using UnityEngine;

public class ShopShower : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private ShopPanel _shopPanel;

    private void OnEnable()
    {
        _inputReader.Entered += Open;
    }
    
    private void OnDisable()
    {
        _inputReader.Entered -= Open;
    }

    private void Open()
    {
        _shopPanel.Show();
    }
}
