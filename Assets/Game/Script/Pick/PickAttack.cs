using UnityEngine;
using Zenject;

public class PickAttack : MonoBehaviour, IPickAttack
{
    [SerializeField] private float _damage = 10f;

    private int _source;
    private Resource _resource;
    private InputReader _inputReader;
    private ViewResourse _viewResourse;

    public float Damage => _damage;
    public int Source => _source;

    [Inject]
    public void Construct(
        Resource resource,
        InputReader inputReader,
        PickAnimation pickAnimation,
        ViewResourse viewResourse)
    {
        _resource = resource;
        _inputReader = inputReader;
        _viewResourse = viewResourse;

        _resource.ResourceDestroyed += AddResource;
        _inputReader.Picked += Attack;

        _viewResourse.ResourceShow(_source);
    }

    private void OnDestroy()
    {
        if (_inputReader != null)
        {
            _inputReader.Picked -= Attack;
        }

        if (_resource != null)
        {
            _resource.ResourceDestroyed -= AddResource;
        }
    }

    private void Attack()
    {
        if (_resource == null)
        {
            return;
        }

        _resource.MineResource(Damage);
    }

    private void AddResource(int amount)
    {
        _source += amount;
        _viewResourse.ResourceShow(_source);
    }
}
