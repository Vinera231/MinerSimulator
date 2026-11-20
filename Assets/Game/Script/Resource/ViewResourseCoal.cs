using TMPro;
using UnityEngine;

public class ViewResourseCoal : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textCoal;

    public void CoalResourceShow(int source)
    {
        _textCoal.text = source.ToString();
    }
}
