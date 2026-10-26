using UnityEngine;
using Zenject;

public class PickAnimation : MonoBehaviour
{
    private static readonly int s_attackAnimationID =
     Animator.StringToHash("PickAttack");

    [SerializeField] private Animator _animator;

    public InputReader _inputReader;

    public void PlayAttack()
    {
        if (_animator == null)
            return;

        _animator.Play(s_attackAnimationID, 0, 0f);
    }
}