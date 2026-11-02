using UnityEngine;
using Zenject;

public class PickAttack : MonoBehaviour, IPickAttack
{
    [SerializeField] private float _damage = 10f;
    [SerializeField] private LayerMask _resourceLayer;

    private PickAnimation _pickAnimation;
    private Resource _resource;
    private InputReader _inputReader;
    private ResourceWallet _resourceWallet;

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

        if (resource != null && resource == _resource)
        {
            _resource.ResourceDestroyed -= AddResource;
            _resource = null;
        }

    }

    [Inject]
    public void Construct(InputReader inputReader, PickAnimation pickAnimation, ResourceWallet resourceWallet)
    {
        _inputReader = inputReader;
        _pickAnimation = pickAnimation;
        _resourceWallet = resourceWallet;

        _inputReader.Picked += Attack;
    }

    private void Attack()
    {
        _pickAnimation.PlayAttack();

        if (_resource != null)
            _resource.MineResource(Damage);
    }

    private void AddResource(ResourceType resourceType, int amount)
    {
        _resourceWallet.AddResource(resourceType, amount);

        if (_resource != null)
        {
            _resource.ResourceDestroyed -= AddResource;
            _resource = null;
        }
    }

    private void OnDestroy()
    {
        if (_inputReader != null)
            _inputReader.Picked -= Attack;
    }
}