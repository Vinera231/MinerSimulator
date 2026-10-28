using TMPro;
using UnityEngine;

public class ViewResourseRock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textRock;

    public void RockResourceShow(int source) =>    
        _textRock.text = source.ToString();
}
