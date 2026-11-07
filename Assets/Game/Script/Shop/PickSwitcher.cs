
using UnityEngine;

public class PickSwitcher : MonoBehaviour
{
    [SerializeField] private PickAnimation _pickAnimation;
    [SerializeField] private GameObject[] _picks;

    private bool[] _isPurchased;
    private GameObject _currentPick;

    public int Count => _picks.Length;

    public void Initialize()
    {
        _isPurchased = new bool[_picks.Length];

        if (_picks.Length == 0)
            return;

        for (int i = 0; i < _picks.Length; i++)
        {
            if (_picks[i] != null)
                _picks[i].SetActive(false);
        }

        _isPurchased[0] = true;

        UseItem(0);
    }

    public bool IsPurchased(int index)
    {
        if (!IsValidIndex(index))
            return false;

        return _isPurchased[index];
    }

    public bool UnlockAndSelect(int index)
    {
        if (!IsValidIndex(index))
            return false;

        _isPurchased[index] = true;

        return UseItem(index);
    }

    public bool UseItem(int index)
    {
        if (!IsValidIndex(index))
            return false;

        if (!_isPurchased[index])
            return false;

        if (_picks[index] == null)
            return false;

        if (_currentPick != null)
            _currentPick.SetActive(false);

        _currentPick = _picks[index];
        _currentPick.SetActive(true);

        Animator animator =
            _currentPick.GetComponentInChildren<Animator>(true);

        if (_pickAnimation != null)
            _pickAnimation.SetAnimation(animator);

        return true;
    }

    private bool IsValidIndex(int index)
    {
        return _isPurchased != null &&
           index >= 0 &&
           index < _picks.Length &&
           _picks[index] != null;
    }
}