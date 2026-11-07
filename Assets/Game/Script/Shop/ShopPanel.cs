using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private ShopInitializer _initializer;

    public void Show()
    {
        gameObject.SetActive(true);
        _initializer?.Init();
    }

    public void Hide() =>
        gameObject.SetActive(false);
}