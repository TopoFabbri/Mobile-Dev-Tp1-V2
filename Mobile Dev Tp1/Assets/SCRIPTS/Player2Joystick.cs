using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Joystick : VirtualJoystick
{
    
    protected override void Awake()
    {
        base.Awake();
    }
    
    protected override void Update()
    {
        base.Update();

        InputManager.Instance.SetAxis("Giro2", X);
        InputManager.Instance.SetAxis("Vertical2", Y);
    }
}