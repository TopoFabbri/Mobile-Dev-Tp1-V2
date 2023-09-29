using UnityEngine;

public class KeyBoardInput : MonoBehaviour
{
    public static void UpdateInput()
    {
        var horizontal = Input.GetAxis("Horizontal1");
        var vertical = Input.GetAxis("Vertical1");
        var horizontal2 = Input.GetAxis("Horizontal2");
        var vertical2 = Input.GetAxis("Vertical2");
        
        if (horizontal != 0 && InputManager.Instance.GetAxis("Giro1") == 0)
            InputManager.Instance.SetAxis("Giro1", horizontal);
        if (vertical != 0 && InputManager.Instance.GetAxis("Vertical1") == 0)
            InputManager.Instance.SetAxis("Vertical1", vertical);

        if (horizontal2 != 0 && InputManager.Instance.GetAxis("Giro2") == 0)
            InputManager.Instance.SetAxis("Giro2", horizontal2);
        if (vertical2 != 0 && InputManager.Instance.GetAxis("Vertical2") == 0)
            InputManager.Instance.SetAxis("Vertical2", vertical2);
    }
}