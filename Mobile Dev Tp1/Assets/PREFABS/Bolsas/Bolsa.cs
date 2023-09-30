using UnityEngine;
using System.Collections;

public class Bolsa : MonoBehaviour
{
	public Pallet.Valores Monto;
	//public int IdPlayer = 0;
	public string TagPlayer = "";
	public Texture2D ImagenInventario;
	Player Pj = null;
	
	bool Desapareciendo;
	public GameObject Particulas;
	public float TiempParts = 2.5f;
	public Renderer renderer;

	// Use this for initialization
	void Start () 
	{
		Monto = Pallet.Valores.Valor2;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if(Desapareciendo)
		{
			TiempParts -= Time.deltaTime;
			if(TiempParts <= 0)
			{
				renderer.enabled = true;
				GetComponent<Collider>().enabled = true;
			}
		}
		
	}
	
	void OnTriggerEnter(Collider coll)
	{
		if(coll.tag == TagPlayer)
		{
			Pj = coll.GetComponent<Player>();
			if(Pj.AgregarBolsa(this))
				Desaparecer();
		}
	}
	
	public void Desaparecer()
	{
		Particulas.SetActive(true);
		Desapareciendo = true;
		
		renderer.enabled = false;
		GetComponent<Collider>().enabled = false;
	
	}
}
