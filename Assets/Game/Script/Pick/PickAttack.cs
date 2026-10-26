using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class PickAttack : MonoBehaviour, IPickAttack
{
    [SerializeField] private float _damage = 10f;
    [SerializeField] private LayerMask _resourceLayer;

    private PickAnimation _pickAnimation;
    private int _source;
    private Resource _resource;
    private InputReader _inputReader;
    private ViewResourse _viewResourse;

    public float Damage => _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((_resourceLayer.value & (1 << collision.gameObject.layer)) == 0)
        {
            return;
        }

        Resource resource = collision.GetComponentInParent<Resource>();

        if (resource == null || resource == _resource)
        {
            return;
        }

        _resource = resource;
        _resource.ResourceDestroyed += AddResource;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Resource resource = collision.GetComponentInParent<Resource>();

        if (resource == _resource)
        {
            _resource.ResourceDestroyed -= AddResource;
            _resource = null;
        }
    }

    [Inject]
    public void Construct(InputReader inputReader, PickAnimation pickAnimation, ViewResourse viewResourse)
    {
        _inputReader = inputReader;
        _viewResourse = viewResourse;
        _pickAnimation = pickAnimation;

        _inputReader.Picked += Attack;
        _viewResourse.ResourceShow(_source);
    }

    private void Attack()
    {
        _pickAnimation.PlayAttack();
        _resource.MineResource(Damage);
    }

    private void AddResource(int amount)
    {
        _source += amount;
        _viewResourse.ResourceShow(_source);
    }
}
