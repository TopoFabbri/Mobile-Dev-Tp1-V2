using System.Collections.Generic;

public class InputManager
{
    private static InputManager instance;

    public static InputManager Instance
    {
        get
        {
            if (instance == null)
                instance = new InputManager();

            return instance;
        }
    }

    Dictionary<string, float> axisValues = new();

    public void SetAxis(string inputName, float value)
    {
        axisValues.TryAdd(inputName, value);

        axisValues[inputName] = value;
    }

    public float GetAxis(string axis)
    {
        axisValues.TryAdd(axis, 0f);

        return axisValues[axis];
    }
}