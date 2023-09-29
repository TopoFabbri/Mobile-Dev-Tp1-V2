using UnityEngine;

public class ControlDireccion : MonoBehaviour 
{
	public enum TipoInput {AWSD, Arrows}
	public TipoInput InputAct = TipoInput.AWSD;

	float Giro = 0;
	
	public bool Habilitado = true;
	CarController carController;
		
	//---------------------------------------------------------//
	
	// Use this for initialization
	void Start () 
	{
		carController = GetComponent<CarController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		KeyboardInput();
		
		if (InputAct == TipoInput.AWSD)
			Giro = InputManager.Instance.GetAxis("Giro1");
		else
			Giro = InputManager.Instance.GetAxis("Giro2");

		carController.SetGiro(Giro);
	}
	
	void KeyboardInput()
	{
		if (Input.GetAxis("Horizontal1") != 0 && InputManager.Instance.GetAxis("Giro1") == 0)
			InputManager.Instance.SetAxis("Giro1", Input.GetAxis("Horizontal1"));
		if (Input.GetAxis("Vertical1") != 0 && InputManager.Instance.GetAxis("Vertical1") == 0)
			InputManager.Instance.SetAxis("Vertical1", Input.GetAxis("Vertical1"));

		if (Input.GetAxis("Horizontal2") != 0 && InputManager.Instance.GetAxis("Giro2") == 0)
			InputManager.Instance.SetAxis("Giro2", Input.GetAxis("Horizontal2"));
		if (Input.GetAxis("Vertical2") != 0 && InputManager.Instance.GetAxis("Vertical2") == 0)
			InputManager.Instance.SetAxis("Vertical2", Input.GetAxis("Vertical2"));
	}
	
	public float GetGiro()
	{
		return Giro;
	}
	
}
