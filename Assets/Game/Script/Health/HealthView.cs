using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HealthView: MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private GameObject _health;

    public void ShowHealth(float health,float maxHealth) =>
        _image.fillAmount = health / maxHealth;

    public void OnViewHealth()
    {
        _health.SetActive(true);
    }
}