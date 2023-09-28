public class Player1Joystick : VirtualJoystick
{
    protected override void Update()
    {
        base.Update();
        
        InputManager.Instance.SetAxis("Giro1", X);
        InputManager.Instance.SetAxis("Vertical1", Y);
    }
}
