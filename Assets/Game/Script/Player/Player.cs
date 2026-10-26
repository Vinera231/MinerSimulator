using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _minHeight = -3f;
    [SerializeField] private float _maxHeight = 5f;
    [SerializeField] private float _minPosition = -7f;
    [SerializeField] private float _maxPosition = 7f;

    private float _rotationPlayer = 180f;

    private void Update()
    {
        float moveX = _inputReader.MoveHorizontal;
        float moveY = _inputReader.MoveVertical;

        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;

        Vector3 position = transform.position;

        position.x += moveDirection.x * _speed * Time.deltaTime;
        position.y += moveDirection.y * _speed * Time.deltaTime;

        position.y = Mathf.Clamp(position.y, _minHeight, _maxHeight);
        position.x = Mathf.Clamp(position.x,_minPosition,_maxPosition);


        transform.position = position;

        if (moveX < 0f)
        {
            transform.rotation = Quaternion.Euler(0f, _rotationPlayer, 0f);
        }
        else if (moveX > 0f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
