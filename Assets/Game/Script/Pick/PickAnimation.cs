using UnityEngine;
using Zenject;

public class PickAnimation : MonoBehaviour
{
    private static readonly int s_attackAnimationID =
     Animator.StringToHash("PickAttack");

    [SerializeField] private Animator _animator;

    private InputReader _inputReader;

    [Inject]
    private void Construct(InputReader inputReader)
    {
        _inputReader = inputReader;
        _inputReader.Picked += PlayAttack;
    }

    private void OnDestroy()
    {
        if (_inputReader != null)
        {
            _inputReader.Picked -= PlayAttack;
        }
    }

    public void PlayAttack()
    {
        _animator.Play(s_attackAnimationID, 0, 0f);
    }
}