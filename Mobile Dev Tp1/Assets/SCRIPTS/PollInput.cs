using UnityEngine;

public class PollInput : MonoBehaviour
{
    [SerializeField] private VirtualJoystick joy1;
    [SerializeField] private VirtualJoystick joy2;
    
    public float x;
    public float y;
    
    private static PollInput instance;

    public static PollInput Instance
    {
        get
        {
            if (instance != null) return instance;

            instance = FindObjectOfType<PollInput>();

            if (instance != null) return instance;

            GameObject singletonObject = new();
            instance = singletonObject.AddComponent<PollInput>();
            singletonObject.name = typeof(PollInput) + " (Singleton)";

            DontDestroyOnLoad(singletonObject);
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
            DestroyImmediate(gameObject);
        else
            instance = this;
    }

    private void Update()
    {
        InputManager.Instance.SetAxis("Giro1", joy1.X);
        InputManager.Instance.SetAxis("Vertical1", joy1.Y);
        InputManager.Instance.SetAxis("Giro2", joy2.X);
        InputManager.Instance.SetAxis("Vertical2", joy2.Y);
        
        float horizontal = Input.GetAxis("Horizontal1");
        float vertical = Input.GetAxis("Vertical1");
        float horizontal2 = Input.GetAxis("Horizontal2");
        float vertical2 = Input.GetAxis("Vertical2");
        
        if (horizontal != 0 && InputManager.Instance.GetAxis("Giro1") == 0)
            InputManager.Instance.SetAxis("Giro1", horizontal);
        if (vertical != 0 && InputManager.Instance.GetAxis("Vertical1") == 0)
            InputManager.Instance.SetAxis("Vertical1", vertical);

        if (horizontal2 != 0 && InputManager.Instance.GetAxis("Giro2") == 0)
            InputManager.Instance.SetAxis("Giro2", horizontal2);
        if (vertical2 != 0 && InputManager.Instance.GetAxis("Vertical2") == 0)
            InputManager.Instance.SetAxis("Vertical2", vertical2);
        
        x = InputManager.Instance.GetAxis("Giro1");
        y = InputManager.Instance.GetAxis("Vertical1");
    }

    private void OnDestroy()
    {
        if (instance == this)
            instance = null;
    }
}