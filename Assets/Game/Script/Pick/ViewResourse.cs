using TMPro;
using UnityEngine;

public class ViewResourse : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void ResourceShow(int source) =>    
        _text.text = source.ToString();
}