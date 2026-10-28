using UnityEngine;
using Zenject;

public class PickAttack : MonoBehaviour, IPickAttack
{
    [SerializeField] private float _damage = 10f;
    [SerializeField] private LayerMask _resourceLayer;

    private PickAnimation _pickAnimation;
    private Resource _resource;
    private InputReader _inputReader;
    private ViewResourseRock _viewResourseRock;
    private ViewResourseOre _viewResourseOre;

    public float Damage => _damage;

    private int _rockAmount;
    private int _ironAmount;

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
    public void Construct(InputReader inputReader, PickAnimation pickAnimation, ViewResourseRock viewResourse,ViewResourseOre viewResourseIron)
    {
        _inputReader = inputReader;
        _viewResourseRock = viewResourse;
        _viewResourseOre = viewResourseIron;
        _pickAnimation = pickAnimation;

        _inputReader.Picked += Attack;
        UpdateViewResource();
    }

    private void Attack()
    {
        _pickAnimation.PlayAttack();
       
        if(_resource != null)
        _resource.MineResource(Damage);
    }

    private void AddResource( ResourceType resourceType,int amount)
    {
        if (resourceType == ResourceType.Rock)
            _rockAmount +=amount;
        else if (resourceType == ResourceType.Ore)
            _ironAmount +=amount;

        UpdateViewResource();
    }

    private void UpdateViewResource()
    {
        _viewResourseRock.RockResourceShow(_rockAmount);
        _viewResourseOre.OreResourceShow(_ironAmount);
    }

    private void OnDestroy()
    {
        if(_inputReader != null)
            _inputReader.Picked -= Attack;

        if(_resource != null)
            _resource.ResourceDestroyed -= AddResource;
    }
}