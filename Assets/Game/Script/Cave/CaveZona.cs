using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveZona : MonoBehaviour 
{
    [SerializeField] private int _index;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(_index);
    }
}
