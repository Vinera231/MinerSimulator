using UnityEngine;

public class ZonaHealth : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HealthView healthView))
            healthView.OnViewHealth();
    }
}
