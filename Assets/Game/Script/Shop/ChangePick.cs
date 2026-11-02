using UnityEngine;

[CreateAssetMenu(fileName = "ChangedPick", menuName = "Pick")]
public class ChangePick : ScriptableObject
{
    [SerializeField] private GameObject _currentPrefab;

    public GameObject CurrentPrefab => _currentPrefab;

    public void CurrentPick(GameObject prefab)
    {
        if (prefab == null)
            return;

        _currentPrefab = prefab;
    }
}
