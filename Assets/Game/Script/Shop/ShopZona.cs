using TMPro;
using UnityEngine;

public class ShopZona : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textShop;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_textShop != null)
        _textShop.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_textShop != null)
            _textShop.gameObject.SetActive(false);
    }
}