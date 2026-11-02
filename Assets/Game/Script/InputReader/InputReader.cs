using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader: MonoBehaviour
{
    private float _delay = 0.4f;

    private float _nextPickTime;
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
        if(Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame && Time.time >= _nextPickTime)
        {
            Picked?.Invoke();        
           _nextPickTime = Time.time + _delay;
        }
       
        if(Keyboard.current != null && Keyboard.current.eKey.isPressed)
            Entered?.Invoke();
    }
}