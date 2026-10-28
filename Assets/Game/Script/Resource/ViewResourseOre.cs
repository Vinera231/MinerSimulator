using TMPro;
using UnityEngine;

public class ViewResourseOre : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textOre;

    public void OreResourceShow(int source) =>
        _textOre.text = source.ToString();
}
