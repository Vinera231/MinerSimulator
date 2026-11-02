using UnityEngine;

public class PickAnimation : MonoBehaviour
{
    private static readonly int s_attackAnimationID =
     Animator.StringToHash("PickAttack");

    [SerializeField] private Animator _animator;

    public bool _isPlaying {  get; private set; }
    public InputReader _inputReader;

    public void PlayAttack()
    {
        if (_animator != null || _isPlaying)
            _isPlaying = false;

        _isPlaying = true;
        _animator.Play(s_attackAnimationID, 0, 0f);
    }      
}