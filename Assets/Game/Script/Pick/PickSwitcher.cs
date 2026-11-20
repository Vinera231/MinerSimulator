
using UnityEngine;

public class PickSwitcher : MonoBehaviour
{
    [SerializeField] private PickAnimation _pickAnimation;
    [SerializeField] private GameObject[] _picks;

    private bool[] _isPurchased;
    private GameObject _currentPick;
    public int _currentPickIndex;

    public int Count => _picks.Length;

    public void Initialize()
    {
        SaveData saveData = Save.LoadGame();
        _isPurchased = new bool[_picks.Length];

        if (_picks.Length == 0)
            return;

        for (int i = 0; i < _picks.Length; i++)
        {
            if (_picks[i] != null)
                _picks[i].SetActive(false);

            if (saveData.PurchasedPick != null &&
              i < saveData.PurchasedPick.Length)
            {
                _isPurchased[i] = saveData.PurchasedPick[i];
            }
        }

        _isPurchased[0] = true;

        if (saveData.PurchasedPickCount >= 0 && saveData.PurchasedPickCount < _picks.Length &&
            _isPurchased[saveData.PurchasedPickCount])
            _currentPickIndex = saveData.PurchasedPickCount;

        UseItem(_currentPickIndex);
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
       _currentPickIndex = index;

        _currentPick.SetActive(true);

        Animator animator =
            _currentPick.GetComponentInChildren<Animator>(true);

        if (_pickAnimation != null)
            _pickAnimation.SetAnimation(animator);

        SavePick();
        return true;
    }

    private bool IsValidIndex(int index)
    {
        return _isPurchased != null &&
           index >= 0 &&
           index < _picks.Length &&
           _picks[index] != null;
    }

    public void SavePick()
    {
        SaveData saveData = Save.LoadGame();

        saveData.PurchasedPick = _isPurchased;
        saveData.PurchasedPickCount = _currentPickIndex;

        Save.SaveGame(saveData);
    }
}