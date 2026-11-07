using UnityEngine;
using Zenject;

public class ZonaHealth : MonoBehaviour
{
    [SerializeField] private GameObject _showHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            _showHealth.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            _showHealth.SetActive(false);
    }
}