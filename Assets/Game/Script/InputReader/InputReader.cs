using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader: MonoBehaviour
{
    private const KeyCode _shopOpen = KeyCode.E;
    public float MoveVertical
    {
        get
        {
            if (Keyboard.current == null)
                return 0f;

            float moveY = 0f;

            if (Keyboard.current.wKey.isPressed)
                moveY = 1f;
          
            if (Keyboard.current.sKey.isPressed)
                moveY = -1f;

            return moveY;
        }
    }  

    public float MoveHorizontal
    {
        get
        {
            if (Keyboard.current == null)
                return 0f;

            float moveX = 0f;

            if (Keyboard.current.dKey.isPressed)
                moveX = 1f;
           
            if (Keyboard.current.aKey.isPressed)
                moveX = -1f;

            return moveX;
        }
    }

    public event Action Picked;
    public event Action Entered;

    public void Update()
    {     
        if(Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
            Picked?.Invoke();

        if(Keyboard.current != null && Keyboard.current.eKey.isPressed)
            Entered?.Invoke();
    }
}