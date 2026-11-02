using UnityEngine;
using UnityEngine.UI;

public class HealthView: MonoBehaviour
{
    [SerializeField] private Image _image;

    public void ShowHealth(float health,float maxHealth) =>
        _image.fillAmount = health / maxHealth;
}