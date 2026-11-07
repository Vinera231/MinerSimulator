using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShopZona : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textShop;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private ShopShower _shopShower;

    private void Start() =>
        _textShop.gameObject.SetActive(false);

    private void OnTriggerEnter2D()
    {
        _textShop.gameObject.SetActive(true);
        _inputReader.Entered += Open;
    }

    private void OnTriggerExit2D()
    {
        _textShop.gameObject.SetActive(false);
        _inputReader.Entered -= Open;
    }

    private void Open() =>
        _shopShower.ShowPanel();
}