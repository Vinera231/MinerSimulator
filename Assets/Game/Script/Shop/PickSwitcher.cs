using UnityEngine;

public class PickSwitcher : MonoBehaviour
{
    [SerializeField] private ChangePick _changPick;
    [SerializeField] private Transform _pickTransform;
    [SerializeField] private GameObject _currentPick;
   
    public void Change()
    {
        if (_changPick.CurrentPrefab == null)
            return;

        if (_currentPick != null)
            Destroy(_currentPick);

        _currentPick = Instantiate(_changPick.CurrentPrefab, _pickTransform.position, _pickTransform.rotation);
    }
}