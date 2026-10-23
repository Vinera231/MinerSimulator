using System;
using UnityEngine;

public class InputReader: MonoBehaviour
{
    private const  KeyCode _mouseClick = KeyCode.Mouse0;

    public bool MoveUp => Input.GetKey(KeyCode.W);
    public bool MoveDown => Input.GetKey(KeyCode.S);

    public event Action Picked;

    public void Update()
    {
        ReadPickKeyCode();
    }

    public void ReadPickKeyCode()
    {
        if(Input.GetKeyDown(_mouseClick))
            Picked?.Invoke();
    }
}