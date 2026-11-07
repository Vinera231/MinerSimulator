using UnityEngine;

public class PickAnimation : MonoBehaviour
{
    private static readonly int s_attackAnimationID =
        Animator.StringToHash("PickAttack");

    [SerializeField] private Animator _animator;

    public bool IsPlaying { get; private set; }

    public void SetAnimation(Animator animator)
    {
        _animator = animator;
        IsPlaying = false;
    }

    public void PlayAttack()
    {
        if (_animator == null)
            return;

        IsPlaying = true;
        _animator.Play(s_attackAnimationID, 0, 0f);
    }

    public void OnAttackAnimationEnd()
    {
        IsPlaying = false;
    }
}